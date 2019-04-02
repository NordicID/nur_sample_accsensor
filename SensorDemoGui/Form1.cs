using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NurApiDotNet;
using static NurApiDotNet.NurApi;

namespace SensorDemo
{
    public partial class Form1 : Form
    {
        private NurApi nur;

        public Form1()
        {
            nur = new NurApi();
            InitializeComponent();
            nur.ConnectedEvent += Nur_ConnectedEvent;
            nur.DisconnectedEvent += Nur_DisconnectedEvent;
            nur.IOChangeEvent += new EventHandler<IOChangeEventArgs>(IOChangeEventHandler);
            nur.AccessoryRangeDataEvent += new EventHandler<AccessoryRangeDataEventArgs>(RangeDataEventHandler);
        }

        private ListViewItem FindSensorDataListViewItem(int source)
        {
            ListView.ListViewItemCollection items = sensorDataListView.Items;
            foreach (ListViewItem item in items)
            {
                AccessorySensorConfig cfg = (AccessorySensorConfig)item.Tag;
                if (cfg.source == source)
                {
                    return item;
                }
            }
            return null;
        }

        private void IOChangeEventHandler(object sender, IOChangeEventArgs e)
        {
            ListViewItem item = FindSensorDataListViewItem(e.data.source + 128);
            if (item != null)
            {
                item.SubItems[3].Text = e.data.dir.ToString();
                item.SubItems[4].Text = e.timestamp.ToString();
            }
        }

        private void RangeDataEventHandler(object sender, AccessoryRangeDataEventArgs e)
        {
            ListViewItem item = FindSensorDataListViewItem(e.rangeData.source);
            if (item != null)
            {
                item.SubItems[1].Text = e.rangeData.range.ToString();
                item.SubItems[2].Text = e.timestamp.ToString();
            }
        }

        private void Nur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            statusLabel.Text = "Disconnected";
        }

        private void Nur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            statusLabel.Text = "Connected";
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

        private void EnumerateSensors()
        {
            sensorListView.Items.Clear();
            sensorDataListView.Items.Clear();
            try
            {
                List<AccessorySensorConfig> list = nur.AccSensorEnumerate();
                foreach (var s in list)
                {
                    ListViewItem item = new ListViewItem(new string[] {
                        $"{((AccessorySensorType)s.type).ToString()}",
                        $"{s.source}",
                        $"{s.feature}",
                        $"{s.mode}"})
                    {
                        Tag = s
                    };
                    sensorListView.Items.Add(item);

                    item = new ListViewItem(new string[] {
                        $"{s.source}",
                        null,
                        null,
                        null,
                        null})
                    {
                        Tag = s
                    };
                    sensorDataListView.Items.Add(item);
                }
                modeBox.Clear();
                modeBox.Enabled = false;
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
            ListView.SelectedListViewItemCollection items = sensorListView.SelectedItems;
            foreach (ListViewItem item in items)
            {
                AccessorySensorConfig cfg = (AccessorySensorConfig)item.Tag;
                return cfg;
            }
            return null;
        }

        private void SensorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = sensorListView.SelectedItems;
            AccessorySensorConfig? cfg = GetSelectedConfig();

            if (cfg.HasValue)
            {
                modeBox.Enabled = true;
                modeBox.Text = cfg.Value.mode.ToString();
                AccessorySensorFilter filter = nur.AccSensorGetFilter(cfg.Value.source);
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
                return;
            }
            else
            {
                modeBox.Clear();
                modeBox.Enabled = false;
                getValueTextBox.Clear();
            }
        }

        private void EditConfButton_Click(object sender, EventArgs e)
        {
            int mode = int.Parse(modeBox.Text);
            AccessorySensorConfig? cfg = GetSelectedConfig();
            if (cfg.HasValue)
            {
                AccessorySensorConfig c = cfg.Value;
                c.mode = (byte)mode;
                nur.AccSensorSetConfig(c);
                EnumerateSensors();
            }
        }

        private void EditFiltersButton_Click(object sender, EventArgs e)
        {
            AccessorySensorConfig? cfg = GetSelectedConfig();
            if (cfg.HasValue)
            {
                AccessorySensorFilter filter = new AccessorySensorFilter();
                AccessorySensorFilterFlag flags = 0;
                if (rangeCheckBox.Checked)
                    flags |= AccessorySensorFilterFlag.Range;
                if (timeCheckBox.Checked)
                    flags |= AccessorySensorFilterFlag.Time;
                filter.flags = (ushort)flags;

                filter.rangeThreshold.lo = ushort.Parse(rangeLoTextBox.Text);
                filter.rangeThreshold.hi = ushort.Parse(rangeHiTextBox.Text);

                filter.timeThreshold.lo = ushort.Parse(timeLoTextBox.Text);
                filter.timeThreshold.hi = ushort.Parse(timeHiTextBox.Text);

                nur.AccSensorSetFilter(cfg.Value.source, filter);
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
