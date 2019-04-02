namespace SensorDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sensorListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.refreshButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.editConfButton = new System.Windows.Forms.Button();
            this.modeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.editFiltersButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.timeHiTextBox = new System.Windows.Forms.TextBox();
            this.timeLoTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rangeHiTextBox = new System.Windows.Forms.TextBox();
            this.rangeCheckBox = new System.Windows.Forms.CheckBox();
            this.rangeLoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.getValueButton = new System.Windows.Forms.Button();
            this.getValueTextBox = new System.Windows.Forms.TextBox();
            this.sensorDataListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.textBoxIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reader details";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(46, 39);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(73, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Disconnected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(92, 55);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(49, 16);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(226, 20);
            this.textBoxIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sensorListView);
            this.groupBox2.Controls.Add(this.refreshButton);
            this.groupBox2.Location = new System.Drawing.Point(10, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 196);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensors";
            // 
            // sensorListView
            // 
            this.sensorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.sensorListView.HideSelection = false;
            this.sensorListView.Location = new System.Drawing.Point(10, 19);
            this.sensorListView.MultiSelect = false;
            this.sensorListView.Name = "sensorListView";
            this.sensorListView.Size = new System.Drawing.Size(265, 139);
            this.sensorListView.TabIndex = 2;
            this.sensorListView.UseCompatibleStateImageBehavior = false;
            this.sensorListView.View = System.Windows.Forms.View.Details;
            this.sensorListView.SelectedIndexChanged += new System.EventHandler(this.SensorListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Source";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Feature";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mode";
            this.columnHeader4.Width = 50;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(92, 164);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.editConfButton);
            this.groupBox3.Controls.Add(this.modeBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(301, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(121, 86);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuration";
            // 
            // editConfButton
            // 
            this.editConfButton.Location = new System.Drawing.Point(20, 55);
            this.editConfButton.Name = "editConfButton";
            this.editConfButton.Size = new System.Drawing.Size(75, 23);
            this.editConfButton.TabIndex = 2;
            this.editConfButton.Text = "Edit";
            this.editConfButton.UseVisualStyleBackColor = true;
            this.editConfButton.Click += new System.EventHandler(this.EditConfButton_Click);
            // 
            // modeBox
            // 
            this.modeBox.Enabled = false;
            this.modeBox.Location = new System.Drawing.Point(40, 16);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(31, 20);
            this.modeBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mode";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.editFiltersButton);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(301, 111);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(121, 279);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filters";
            // 
            // editFiltersButton
            // 
            this.editFiltersButton.Location = new System.Drawing.Point(20, 244);
            this.editFiltersButton.Name = "editFiltersButton";
            this.editFiltersButton.Size = new System.Drawing.Size(75, 23);
            this.editFiltersButton.TabIndex = 2;
            this.editFiltersButton.Text = "Edit";
            this.editFiltersButton.UseVisualStyleBackColor = true;
            this.editFiltersButton.Click += new System.EventHandler(this.EditFiltersButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.timeHiTextBox);
            this.groupBox6.Controls.Add(this.timeLoTextBox);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.timeCheckBox);
            this.groupBox6.Location = new System.Drawing.Point(9, 131);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(95, 107);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Time";
            // 
            // timeHiTextBox
            // 
            this.timeHiTextBox.Location = new System.Drawing.Point(31, 65);
            this.timeHiTextBox.Name = "timeHiTextBox";
            this.timeHiTextBox.Size = new System.Drawing.Size(55, 20);
            this.timeHiTextBox.TabIndex = 4;
            // 
            // timeLoTextBox
            // 
            this.timeLoTextBox.Location = new System.Drawing.Point(31, 39);
            this.timeLoTextBox.Name = "timeLoTextBox";
            this.timeLoTextBox.Size = new System.Drawing.Size(55, 20);
            this.timeLoTextBox.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Hi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Lo";
            // 
            // timeCheckBox
            // 
            this.timeCheckBox.AutoSize = true;
            this.timeCheckBox.Location = new System.Drawing.Point(9, 18);
            this.timeCheckBox.Name = "timeCheckBox";
            this.timeCheckBox.Size = new System.Drawing.Size(65, 17);
            this.timeCheckBox.TabIndex = 0;
            this.timeCheckBox.Text = "Enabled";
            this.timeCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rangeHiTextBox);
            this.groupBox5.Controls.Add(this.rangeCheckBox);
            this.groupBox5.Controls.Add(this.rangeLoTextBox);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(9, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(95, 106);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Range";
            // 
            // rangeHiTextBox
            // 
            this.rangeHiTextBox.Location = new System.Drawing.Point(31, 71);
            this.rangeHiTextBox.Name = "rangeHiTextBox";
            this.rangeHiTextBox.Size = new System.Drawing.Size(55, 20);
            this.rangeHiTextBox.TabIndex = 4;
            // 
            // rangeCheckBox
            // 
            this.rangeCheckBox.AutoSize = true;
            this.rangeCheckBox.Location = new System.Drawing.Point(9, 19);
            this.rangeCheckBox.Name = "rangeCheckBox";
            this.rangeCheckBox.Size = new System.Drawing.Size(65, 17);
            this.rangeCheckBox.TabIndex = 3;
            this.rangeCheckBox.Text = "Enabled";
            this.rangeCheckBox.UseVisualStyleBackColor = true;
            // 
            // rangeLoTextBox
            // 
            this.rangeLoTextBox.Location = new System.Drawing.Point(31, 39);
            this.rangeLoTextBox.Name = "rangeLoTextBox";
            this.rangeLoTextBox.Size = new System.Drawing.Size(55, 20);
            this.rangeLoTextBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Hi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lo";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.sensorDataListView);
            this.groupBox7.Controls.Add(this.getValueButton);
            this.groupBox7.Controls.Add(this.getValueTextBox);
            this.groupBox7.Location = new System.Drawing.Point(10, 303);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(285, 165);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Sensor Values";
            // 
            // getValueButton
            // 
            this.getValueButton.Location = new System.Drawing.Point(13, 16);
            this.getValueButton.Name = "getValueButton";
            this.getValueButton.Size = new System.Drawing.Size(75, 23);
            this.getValueButton.TabIndex = 2;
            this.getValueButton.Text = "Get Value";
            this.getValueButton.UseVisualStyleBackColor = true;
            this.getValueButton.Click += new System.EventHandler(this.GetValueButton_Click);
            // 
            // getValueTextBox
            // 
            this.getValueTextBox.Location = new System.Drawing.Point(107, 16);
            this.getValueTextBox.Name = "getValueTextBox";
            this.getValueTextBox.ReadOnly = true;
            this.getValueTextBox.Size = new System.Drawing.Size(60, 20);
            this.getValueTextBox.TabIndex = 1;
            // 
            // sensorDataListView
            // 
            this.sensorDataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.sensorDataListView.Location = new System.Drawing.Point(13, 45);
            this.sensorDataListView.Name = "sensorDataListView";
            this.sensorDataListView.Size = new System.Drawing.Size(262, 108);
            this.sensorDataListView.TabIndex = 3;
            this.sensorDataListView.UseCompatibleStateImageBehavior = false;
            this.sensorDataListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Source";
            this.columnHeader5.Width = 46;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Value";
            this.columnHeader6.Width = 45;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Timestamp";
            this.columnHeader7.Width = 65;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "State";
            this.columnHeader8.Width = 37;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Timestamp";
            this.columnHeader9.Width = 65;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView sensorListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox modeBox;
        private System.Windows.Forms.Button editConfButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox timeHiTextBox;
        private System.Windows.Forms.TextBox timeLoTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox timeCheckBox;
        private System.Windows.Forms.TextBox rangeHiTextBox;
        private System.Windows.Forms.CheckBox rangeCheckBox;
        private System.Windows.Forms.TextBox rangeLoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button editFiltersButton;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox getValueTextBox;
        private System.Windows.Forms.Button getValueButton;
        private System.Windows.Forms.ListView sensorDataListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}

