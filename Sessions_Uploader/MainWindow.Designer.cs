namespace Sessions_Uploader
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lblChooseServer = new System.Windows.Forms.Label();
            this.comboBoxServers = new System.Windows.Forms.ComboBox();
            this.btnUploadSession = new System.Windows.Forms.Button();
            this.lblStatusChanging = new System.Windows.Forms.Label();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.panelInterval = new System.Windows.Forms.Panel();
            this.labelFilesInterval = new System.Windows.Forms.Label();
            this.howManyTimes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.clearTemp = new System.Windows.Forms.CheckBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.BrowseSource = new System.Windows.Forms.Button();
            this.directorySourceTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openTempBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.automaticIntervalCheckBox = new System.Windows.Forms.CheckBox();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.directoryOutputTextBox = new System.Windows.Forms.TextBox();
            this.BrowseOutput = new System.Windows.Forms.Button();
            this.examinationCreatorSwithCheckBox = new System.Windows.Forms.CheckBox();
            this.panelInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.howManyTimes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChooseServer
            // 
            this.lblChooseServer.AutoSize = true;
            this.lblChooseServer.Location = new System.Drawing.Point(8, 19);
            this.lblChooseServer.Name = "lblChooseServer";
            this.lblChooseServer.Size = new System.Drawing.Size(78, 13);
            this.lblChooseServer.TabIndex = 0;
            this.lblChooseServer.Text = "Choose server:";
            // 
            // comboBoxServers
            // 
            this.comboBoxServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServers.FormattingEnabled = true;
            this.comboBoxServers.Items.AddRange(new object[] {
            "Examination Creator",
            "triss-3",
            "triss-2",
            "triss-1",
            "yennefer-3",
            "yennefer-2",
            "yennefer-1",
            "fringilla-3",
            "fringilla-2",
            "fringilla-1",
            "klatch-1",
            "klatch-2",
            "uberwald-1",
            "quirm-1"});
            this.comboBoxServers.Location = new System.Drawing.Point(8, 35);
            this.comboBoxServers.Name = "comboBoxServers";
            this.comboBoxServers.Size = new System.Drawing.Size(227, 21);
            this.comboBoxServers.TabIndex = 1;
            // 
            // btnUploadSession
            // 
            this.btnUploadSession.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnUploadSession.Location = new System.Drawing.Point(197, 332);
            this.btnUploadSession.Name = "btnUploadSession";
            this.btnUploadSession.Size = new System.Drawing.Size(186, 27);
            this.btnUploadSession.TabIndex = 2;
            this.btnUploadSession.Text = "Upload Files";
            this.btnUploadSession.UseVisualStyleBackColor = false;
            this.btnUploadSession.Click += new System.EventHandler(this.btnUploadSession_Click);
            // 
            // lblStatusChanging
            // 
            this.lblStatusChanging.AutoSize = true;
            this.lblStatusChanging.Location = new System.Drawing.Point(171, 71);
            this.lblStatusChanging.Name = "lblStatusChanging";
            this.lblStatusChanging.Size = new System.Drawing.Size(0, 13);
            this.lblStatusChanging.TabIndex = 4;
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(132, 1);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(41, 20);
            this.textBoxInterval.TabIndex = 6;
            this.textBoxInterval.Text = "1";
            this.textBoxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInterval_KeyPress);
            // 
            // panelInterval
            // 
            this.panelInterval.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelInterval.Controls.Add(this.labelFilesInterval);
            this.panelInterval.Controls.Add(this.textBoxInterval);
            this.panelInterval.Location = new System.Drawing.Point(8, 62);
            this.panelInterval.Name = "panelInterval";
            this.panelInterval.Size = new System.Drawing.Size(186, 26);
            this.panelInterval.TabIndex = 7;
            // 
            // labelFilesInterval
            // 
            this.labelFilesInterval.AutoSize = true;
            this.labelFilesInterval.Location = new System.Drawing.Point(2, 4);
            this.labelFilesInterval.Name = "labelFilesInterval";
            this.labelFilesInterval.Size = new System.Drawing.Size(124, 13);
            this.labelFilesInterval.TabIndex = 8;
            this.labelFilesInterval.Text = "Files start minus interval: ";
            // 
            // howManyTimes
            // 
            this.howManyTimes.Location = new System.Drawing.Point(144, 103);
            this.howManyTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.howManyTimes.Name = "howManyTimes";
            this.howManyTimes.Size = new System.Drawing.Size(39, 20);
            this.howManyTimes.TabIndex = 8;
            this.howManyTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.howManyTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "How many examinations:";
            // 
            // clearTemp
            // 
            this.clearTemp.AutoSize = true;
            this.clearTemp.Location = new System.Drawing.Point(9, 19);
            this.clearTemp.Name = "clearTemp";
            this.clearTemp.Size = new System.Drawing.Size(119, 17);
            this.clearTemp.TabIndex = 10;
            this.clearTemp.Text = "Clear temp. location";
            this.clearTemp.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(134, 14);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 11;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // BrowseSource
            // 
            this.BrowseSource.Location = new System.Drawing.Point(485, 17);
            this.BrowseSource.Name = "BrowseSource";
            this.BrowseSource.Size = new System.Drawing.Size(75, 23);
            this.BrowseSource.TabIndex = 12;
            this.BrowseSource.Text = "Browse";
            this.BrowseSource.UseVisualStyleBackColor = true;
            this.BrowseSource.Click += new System.EventHandler(this.BrowseSource_Click);
            // 
            // directorySourceTextBox
            // 
            this.directorySourceTextBox.Location = new System.Drawing.Point(6, 19);
            this.directorySourceTextBox.Name = "directorySourceTextBox";
            this.directorySourceTextBox.Size = new System.Drawing.Size(473, 20);
            this.directorySourceTextBox.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.directorySourceTextBox);
            this.groupBox1.Controls.Add(this.BrowseSource);
            this.groupBox1.Location = new System.Drawing.Point(4, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 54);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source directory";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.openTempBtn);
            this.groupBox2.Controls.Add(this.clearTemp);
            this.groupBox2.Controls.Add(this.clearBtn);
            this.groupBox2.Location = new System.Drawing.Point(327, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 94);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // openTempBtn
            // 
            this.openTempBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.openTempBtn.Location = new System.Drawing.Point(45, 58);
            this.openTempBtn.Name = "openTempBtn";
            this.openTempBtn.Size = new System.Drawing.Size(118, 23);
            this.openTempBtn.TabIndex = 12;
            this.openTempBtn.Text = "Open temp location";
            this.openTempBtn.UseVisualStyleBackColor = false;
            this.openTempBtn.Click += new System.EventHandler(this.openTempBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.automaticIntervalCheckBox);
            this.groupBox3.Controls.Add(this.lblChooseServer);
            this.groupBox3.Controls.Add(this.comboBoxServers);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.howManyTimes);
            this.groupBox3.Controls.Add(this.panelInterval);
            this.groupBox3.Location = new System.Drawing.Point(4, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 146);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // automaticIntervalCheckBox
            // 
            this.automaticIntervalCheckBox.AutoSize = true;
            this.automaticIntervalCheckBox.Checked = true;
            this.automaticIntervalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automaticIntervalCheckBox.Location = new System.Drawing.Point(201, 62);
            this.automaticIntervalCheckBox.Name = "automaticIntervalCheckBox";
            this.automaticIntervalCheckBox.Size = new System.Drawing.Size(109, 17);
            this.automaticIntervalCheckBox.TabIndex = 10;
            this.automaticIntervalCheckBox.Text = "automatic interval";
            this.automaticIntervalCheckBox.UseVisualStyleBackColor = true;
            this.automaticIntervalCheckBox.CheckedChanged += new System.EventHandler(this.automaticIntervalCheckBox_CheckedChanged);
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.directoryOutputTextBox);
            this.OutputGroupBox.Controls.Add(this.BrowseOutput);
            this.OutputGroupBox.Enabled = false;
            this.OutputGroupBox.Location = new System.Drawing.Point(4, 98);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(566, 54);
            this.OutputGroupBox.TabIndex = 17;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "Output directory (for examination creator)";
            // 
            // directoryOutputTextBox
            // 
            this.directoryOutputTextBox.Location = new System.Drawing.Point(6, 19);
            this.directoryOutputTextBox.Name = "directoryOutputTextBox";
            this.directoryOutputTextBox.Size = new System.Drawing.Size(473, 20);
            this.directoryOutputTextBox.TabIndex = 13;
            // 
            // BrowseOutput
            // 
            this.BrowseOutput.Location = new System.Drawing.Point(485, 17);
            this.BrowseOutput.Name = "BrowseOutput";
            this.BrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.BrowseOutput.TabIndex = 12;
            this.BrowseOutput.Text = "Browse";
            this.BrowseOutput.UseVisualStyleBackColor = true;
            this.BrowseOutput.Click += new System.EventHandler(this.BrowseOutput_Click);
            // 
            // examinationCreatorSwithCheckBox
            // 
            this.examinationCreatorSwithCheckBox.AutoSize = true;
            this.examinationCreatorSwithCheckBox.Location = new System.Drawing.Point(4, 75);
            this.examinationCreatorSwithCheckBox.Name = "examinationCreatorSwithCheckBox";
            this.examinationCreatorSwithCheckBox.Size = new System.Drawing.Size(119, 17);
            this.examinationCreatorSwithCheckBox.TabIndex = 18;
            this.examinationCreatorSwithCheckBox.Text = "Examination creator";
            this.examinationCreatorSwithCheckBox.UseVisualStyleBackColor = true;
            this.examinationCreatorSwithCheckBox.CheckedChanged += new System.EventHandler(this.examinationCreatorSwithCheckBox_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(582, 371);
            this.Controls.Add(this.examinationCreatorSwithCheckBox);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatusChanging);
            this.Controls.Add(this.btnUploadSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Sessions Uploder";
            this.panelInterval.ResumeLayout(false);
            this.panelInterval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.howManyTimes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.OutputGroupBox.ResumeLayout(false);
            this.OutputGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseServer;
        private System.Windows.Forms.ComboBox comboBoxServers;
        private System.Windows.Forms.Button btnUploadSession;
        private System.Windows.Forms.Label lblStatusChanging;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Panel panelInterval;
        private System.Windows.Forms.Label labelFilesInterval;
        private System.Windows.Forms.NumericUpDown howManyTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox clearTemp;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button BrowseSource;
        private System.Windows.Forms.TextBox directorySourceTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.TextBox directoryOutputTextBox;
        private System.Windows.Forms.Button BrowseOutput;
        private System.Windows.Forms.CheckBox examinationCreatorSwithCheckBox;
        private System.Windows.Forms.Button openTempBtn;
        private System.Windows.Forms.CheckBox automaticIntervalCheckBox;
    }
}

