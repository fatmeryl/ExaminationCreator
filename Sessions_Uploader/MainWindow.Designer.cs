﻿namespace Sessions_Uploader
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
            this.howManyTimes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseSource = new System.Windows.Forms.Button();
            this.directorySourceTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openTempBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.openConfigBtn = new System.Windows.Forms.Button();
            this.clearTempOptionCheckBox = new System.Windows.Forms.CheckBox();
            this.tempFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.tempFolderTekstBox = new System.Windows.Forms.TextBox();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.directoryOutputTextBox = new System.Windows.Forms.TextBox();
            this.BrowseOutput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.howManyTimes)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.comboBoxServers.Location = new System.Drawing.Point(8, 35);
            this.comboBoxServers.Name = "comboBoxServers";
            this.comboBoxServers.Size = new System.Drawing.Size(227, 21);
            this.comboBoxServers.TabIndex = 1;
            this.comboBoxServers.TextChanged += new System.EventHandler(this.comboBoxServers_TextChanged);
            // 
            // btnUploadSession
            // 
            this.btnUploadSession.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnUploadSession.Location = new System.Drawing.Point(195, 387);
            this.btnUploadSession.Name = "btnUploadSession";
            this.btnUploadSession.Size = new System.Drawing.Size(186, 25);
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
            // howManyTimes
            // 
            this.howManyTimes.Location = new System.Drawing.Point(144, 74);
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
            this.howManyTimes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HowManyTimes_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "How many examinations:";
            // 
            // BrowseSource
            // 
            this.BrowseSource.Location = new System.Drawing.Point(485, 16);
            this.BrowseSource.Name = "BrowseSource";
            this.BrowseSource.Size = new System.Drawing.Size(75, 25);
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
            this.directorySourceTextBox.TextChanged += new System.EventHandler(this.directorySourceTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.directorySourceTextBox);
            this.groupBox1.Controls.Add(this.BrowseSource);
            this.groupBox1.Location = new System.Drawing.Point(4, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 54);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source directory";
            // 
            // openTempBtn
            // 
            this.openTempBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.openTempBtn.Location = new System.Drawing.Point(442, 160);
            this.openTempBtn.Name = "openTempBtn";
            this.openTempBtn.Size = new System.Drawing.Size(118, 25);
            this.openTempBtn.TabIndex = 12;
            this.openTempBtn.Text = "Open temp location";
            this.openTempBtn.UseVisualStyleBackColor = false;
            this.openTempBtn.Click += new System.EventHandler(this.openTempBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.openTempBtn);
            this.groupBox3.Controls.Add(this.openConfigBtn);
            this.groupBox3.Controls.Add(this.clearTempOptionCheckBox);
            this.groupBox3.Controls.Add(this.tempFolderCheckBox);
            this.groupBox3.Controls.Add(this.tempFolderTekstBox);
            this.groupBox3.Controls.Add(this.lblChooseServer);
            this.groupBox3.Controls.Add(this.comboBoxServers);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.howManyTimes);
            this.groupBox3.Location = new System.Drawing.Point(4, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(566, 206);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // openConfigBtn
            // 
            this.openConfigBtn.Location = new System.Drawing.Point(453, 35);
            this.openConfigBtn.Name = "openConfigBtn";
            this.openConfigBtn.Size = new System.Drawing.Size(107, 25);
            this.openConfigBtn.TabIndex = 15;
            this.openConfigBtn.Text = "Open config file";
            this.openConfigBtn.UseVisualStyleBackColor = true;
            this.openConfigBtn.Click += new System.EventHandler(this.openConfigBtn_Click);
            // 
            // clearTempOptionCheckBox
            // 
            this.clearTempOptionCheckBox.AutoSize = true;
            this.clearTempOptionCheckBox.Checked = true;
            this.clearTempOptionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearTempOptionCheckBox.Location = new System.Drawing.Point(8, 111);
            this.clearTempOptionCheckBox.Name = "clearTempOptionCheckBox";
            this.clearTempOptionCheckBox.Size = new System.Drawing.Size(167, 17);
            this.clearTempOptionCheckBox.TabIndex = 14;
            this.clearTempOptionCheckBox.Text = "Clear temp. folder after upload";
            this.clearTempOptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // tempFolderCheckBox
            // 
            this.tempFolderCheckBox.AutoSize = true;
            this.tempFolderCheckBox.Location = new System.Drawing.Point(8, 139);
            this.tempFolderCheckBox.Name = "tempFolderCheckBox";
            this.tempFolderCheckBox.Size = new System.Drawing.Size(135, 17);
            this.tempFolderCheckBox.TabIndex = 13;
            this.tempFolderCheckBox.Text = "Temoporary folder path";
            this.tempFolderCheckBox.UseVisualStyleBackColor = true;
            this.tempFolderCheckBox.CheckedChanged += new System.EventHandler(this.tempFolderCheckBox_CheckedChanged);
            // 
            // tempFolderTekstBox
            // 
            this.tempFolderTekstBox.Enabled = false;
            this.tempFolderTekstBox.Location = new System.Drawing.Point(8, 163);
            this.tempFolderTekstBox.Name = "tempFolderTekstBox";
            this.tempFolderTekstBox.Size = new System.Drawing.Size(410, 20);
            this.tempFolderTekstBox.TabIndex = 11;
            this.tempFolderTekstBox.Text = "C:\\SessionUploader";
            this.tempFolderTekstBox.TextChanged += new System.EventHandler(this.tempFolderTekstBox_TextChanged);
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.directoryOutputTextBox);
            this.OutputGroupBox.Controls.Add(this.BrowseOutput);
            this.OutputGroupBox.Location = new System.Drawing.Point(4, 296);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(566, 54);
            this.OutputGroupBox.TabIndex = 17;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "Output directory for examination creator";
            this.OutputGroupBox.Visible = false;
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
            this.BrowseOutput.Location = new System.Drawing.Point(485, 16);
            this.BrowseOutput.Name = "BrowseOutput";
            this.BrowseOutput.Size = new System.Drawing.Size(75, 25);
            this.BrowseOutput.TabIndex = 12;
            this.BrowseOutput.Text = "Browse";
            this.BrowseOutput.UseVisualStyleBackColor = true;
            this.BrowseOutput.Click += new System.EventHandler(this.BrowseOutput_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(576, 436);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatusChanging);
            this.Controls.Add(this.btnUploadSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Sessions Uploder";
            ((System.ComponentModel.ISupportInitialize)(this.howManyTimes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown howManyTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseSource;
        private System.Windows.Forms.TextBox directorySourceTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.TextBox directoryOutputTextBox;
        private System.Windows.Forms.Button BrowseOutput;
        private System.Windows.Forms.Button openTempBtn;
        private System.Windows.Forms.CheckBox tempFolderCheckBox;
        private System.Windows.Forms.TextBox tempFolderTekstBox;
        private System.Windows.Forms.CheckBox clearTempOptionCheckBox;
        private System.Windows.Forms.Button openConfigBtn;
    }
}

