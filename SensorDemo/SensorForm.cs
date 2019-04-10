using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NurApiDotNet;
using static NurApiDotNet.NurApi;

namespace SensorDemo
{
    public partial class SensorForm : Form
    {
        private NurApi nur;

        public SensorForm()
        {
            nur = new NurApi(this);
            InitializeComponent();
            Application.ApplicationExit += Application_ApplicationExit;
            try
            {
                /* Catch reader connect/disconnect events */
                nur.ConnectedEvent += Nur_ConnectedEvent;
                nur.DisconnectedEvent += Nur_DisconnectedEvent;

                /* Catch GPIO pin events */
                nur.IOChangeEvent += new EventHandler<IOChangeEventArgs>(IOChangeEventHandler);
                /* Catch sensor added/removed events */
                nur.AccessorySensorChangedEvent += new EventHandler<AccessorySensorChangedEventArgs>(SensorChangedEventHandler);
                /* Catch streamed raw values from sensor */
                nur.AccessoryRangeDataEvent += new EventHandler<AccessoryRangeDataEventArgs>(RangeDataEventHandler);
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            nur.Dispose();
        }

        private ListViewItem FindSensorDataListViewItem(int source)
        {
            foreach (ListViewItem item in sensorDataListView.Items)
            {
                if (item != null)
                {
                    AccessorySensorConfig cfg = (AccessorySensorConfig)item.Tag;
                    if (cfg.source == source)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        private ListViewItem FindSensorListViewItem(int source)
        {
            foreach (ListViewItem item in sensorListView.Items)
            {
                if (item != null)
                {
                    AccessorySensorConfig cfg = (AccessorySensorConfig)item.Tag;
                    if (cfg.source == source)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        private void SensorChangedEventHandler(object sender, AccessorySensorChangedEventArgs e)
        {
            if (e.sensorChanged.removed != 0)
            {
                /* Remove sensor from lists if it exists */
                ListViewItem item = FindSensorDataListViewItem(e.sensorChanged.source);
                if (item != null)
                {
                    sensorDataListView.Items.Remove(item);
                }
                item = FindSensorListViewItem(e.sensorChanged.source);
                if (item != null)
                {
                    sensorListView.Items.Remove(item);
                }
            }
            else
            {
                /* Get config for added sensor and add it to lists */
                AccessorySensorConfig cfg;
                try
                {
                    cfg = nur.AccSensorGetConfig(e.sensorChanged.source);
                }
                catch (NurApiException ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                    return;
                }
                AddSensor(cfg);
            }
        }

        /* I/O pin low/high event */
        private void IOChangeEventHandler(object sender, IOChangeEventArgs e)
        {
            int offset = 0;

            if (e.data.sensor)
            {
                /* For compability reasons, 128 needs to be added to the source value in IOChangeEventArgs if
                 * the sensor flag is set. GPIO pin events won't have sensor set, and thus should not be added */
                offset = 128;
            }
            ListViewItem item = FindSensorDataListViewItem(e.data.source + offset);
            if (item != null)
            {
                item.SubItems[3].Text = e.data.dir.ToString();
                item.SubItems[4].Text = e.timestamp.ToString();
            }
        }

        /* Raw stream value from sensor */
        private void RangeDataEventHandler(object sender, AccessoryRangeDataEventArgs e)
        {
            ListViewItem item = FindSensorDataListViewItem(e.rangeData.source);
            if (item != null)
            {
                item.SubItems[1].Text = e.rangeData.range.ToString();
                item.SubItems[2].Text = e.timestamp.ToString();
            }
        }

        private void Nur_DisconnectedEvent(object sender, NurEventArgs e)
        {
            sensorListView.Items.Clear();
            sensorDataListView.Items.Clear();
            statusLabel.Text = "Disconnected";
        }

        private void Nur_ConnectedEvent(object sender, NurEventArgs e)
        {
            statusLabel.Text = "Connected";
            EnumerateSensors();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                nur.ConnectSocket(textBoxIP.Text, 4333);
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void AddSensor(AccessorySensorConfig cfg)
        {
            ListViewItem item = new ListViewItem(new string[] {
                        $"{((AccessorySensorType)cfg.type).ToString()}",
                        $"{cfg.source}",
                        $"{cfg.feature}",
                        $"{cfg.mode}"})
            {
                Tag = cfg
            };
            sensorListView.Items.Add(item);

            item = new ListViewItem(new string[] {
                        $"{cfg.source}",
                        null,
                        null,
                        null,
                        null})
            {
                Tag = cfg
            };
            sensorDataListView.Items.Add(item);
        }

        private void EnumerateSensors()
        {
            sensorListView.Items.Clear();
            sensorDataListView.Items.Clear();
            try
            {
                List<AccessorySensorConfig> list = nur.AccSensorEnumerate();
                foreach (AccessorySensorConfig cfg in list)
                {
                    AddSensor(cfg);
                }
                modeComboBox.Enabled = false;
                getValueTextBox.Clear();
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            EnumerateSensors();
        }

        private AccessorySensorConfig? GetSelectedConfig()
        {
            foreach (ListViewItem item in sensorListView.SelectedItems)
            {
                if (item != null)
                {
                    AccessorySensorConfig cfg = (AccessorySensorConfig)item.Tag;
                    return cfg;
                }
            }
            return null;
        }

        private void SensorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = sensorListView.SelectedItems;
            AccessorySensorConfig? cfg = GetSelectedConfig();

            if (cfg.HasValue)
            {
                modeComboBox.Enabled = true;
                modeComboBox.SelectedIndex = cfg.Value.mode;
                AccessorySensorFilter filter;
                try
                {
                    filter = nur.AccSensorGetFilter(cfg.Value.source);
                }
                catch (NurApiException ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                    return;
                }

                AccessorySensorFeature feature = (AccessorySensorFeature)cfg.Value.feature;
                if (feature.HasFlag(AccessorySensorFeature.Range))
                {
                    rangeCheckBox.Enabled = true;
                }
                else
                {
                    rangeCheckBox.Enabled = false;
                }

                AccessorySensorFilterFlag flags = (AccessorySensorFilterFlag)filter.flags;
                if (flags.HasFlag(AccessorySensorFilterFlag.Range))
                {
                    rangeCheckBox.Checked = true;
                    rangeLoTextBox.Text = filter.rangeThreshold.lo.ToString();
                    rangeHiTextBox.Text = filter.rangeThreshold.hi.ToString();
                }
                else
                {
                    rangeCheckBox.Checked = false;
                    rangeLoTextBox.Text = filter.rangeThreshold.lo.ToString();
                    rangeHiTextBox.Text = filter.rangeThreshold.hi.ToString();
                }
                if (flags.HasFlag(AccessorySensorFilterFlag.Time))
                {
                    timeCheckBox.Checked = true;
                    timeLoTextBox.Text = filter.timeThreshold.lo.ToString();
                    timeHiTextBox.Text = filter.timeThreshold.hi.ToString();
                }
                else
                {
                    timeCheckBox.Checked = false;
                    timeLoTextBox.Text = filter.timeThreshold.lo.ToString();
                    timeHiTextBox.Text = filter.timeThreshold.hi.ToString();
                }
            }
            else
            {
                modeComboBox.Enabled = false;
                getValueTextBox.Clear();
            }
        }

        private void EditConfButton_Click(object sender, EventArgs e)
        {
            AccessorySensorMode mode = (AccessorySensorMode)modeComboBox.SelectedIndex;
            AccessorySensorConfig? cfg = GetSelectedConfig();
            if (cfg.HasValue)
            {
                AccessorySensorConfig c = cfg.Value;
                AccessorySensorFeature feature = (AccessorySensorFeature)cfg.Value.feature;
                /* Check if trying to enable streaming mode on a sensor that doesn't support streaming of raw sensor values */
                if (mode.HasFlag(AccessorySensorMode.Stream) && !feature.HasFlag(AccessorySensorFeature.StreamValue))
                {
                    MessageBox.Show("Sensor does not support streaming raw values", "Error");
                    return;
                }
                c.mode = (byte)mode;
                try
                {
                    c = nur.AccSensorSetConfig(c);
                }
                catch (NurApiException ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                    return;
                }
                foreach (ListViewItem item in sensorListView.Items)
                {
                    if (item != null)
                    {
                        AccessorySensorConfig listCfg = (AccessorySensorConfig)item.Tag;
                        if (listCfg.source == c.source)
                        {
                            item.Tag = c;
                            item.SubItems[3].Text = c.mode.ToString();
                        }
                    }
                }
            }
        }

        private void EditFiltersButton_Click(object sender, EventArgs e)
        {
            AccessorySensorConfig? cfg = GetSelectedConfig();
            if (cfg.HasValue)
            {
                AccessorySensorFilter filter = new AccessorySensorFilter();
                AccessorySensorFeature feature = (AccessorySensorFeature)cfg.Value.feature;
                AccessorySensorFilterFlag flags = 0;
                /* Can only enable range filter if the sensor supports it */
                if (rangeCheckBox.Checked && feature.HasFlag(AccessorySensorFeature.Range))
                    flags |= AccessorySensorFilterFlag.Range;
                if (timeCheckBox.Checked)
                    flags |= AccessorySensorFilterFlag.Time;
                filter.flags = (ushort)flags;

                filter.rangeThreshold.lo = ushort.Parse(rangeLoTextBox.Text);
                filter.rangeThreshold.hi = ushort.Parse(rangeHiTextBox.Text);

                filter.timeThreshold.lo = ushort.Parse(timeLoTextBox.Text);
                filter.timeThreshold.hi = ushort.Parse(timeHiTextBox.Text);

                try
                {
                    nur.AccSensorSetFilter(cfg.Value.source, filter);
                }
                catch (NurApiException ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                    return;
                }
            }
        }

        private void GetValueButton_Click(object sender, EventArgs e)
        {
            AccessorySensorConfig? cfg = GetSelectedConfig();
            if (cfg.HasValue)
            {
                try
                {
                    getValueTextBox.Text = ((AccSensorRangeData)nur.AccSensorGetValue(cfg.Value.source)).range.ToString();
                }
                catch (NurApiException ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                }
            }
        }
    }
}
