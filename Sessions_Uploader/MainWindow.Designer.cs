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
            this.labMedical = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.panelInterval = new System.Windows.Forms.Panel();
            this.labelFilesInterval = new System.Windows.Forms.Label();
            this.howManyTimes = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.howManyTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChooseServer
            // 
            this.lblChooseServer.AutoSize = true;
            this.lblChooseServer.Location = new System.Drawing.Point(22, 13);
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
            "quirm-1",
            "testowa lokalizacja"});
            this.comboBoxServers.Location = new System.Drawing.Point(25, 30);
            this.comboBoxServers.Name = "comboBoxServers";
            this.comboBoxServers.Size = new System.Drawing.Size(227, 21);
            this.comboBoxServers.TabIndex = 1;
            this.comboBoxServers.SelectedIndexChanged += new System.EventHandler(this.comboBoxServers_SelectedIndexChanged);
            // 
            // btnUploadSession
            // 
            this.btnUploadSession.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUploadSession.Location = new System.Drawing.Point(43, 154);
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
            // labMedical
            // 
            this.labMedical.AutoSize = true;
            this.labMedical.Location = new System.Drawing.Point(22, 202);
            this.labMedical.Name = "labMedical";
            this.labMedical.Size = new System.Drawing.Size(78, 13);
            this.labMedical.TabIndex = 3;
            this.labMedical.Text = "Copyright 2018";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(125, 196);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 19);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(132, 1);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(41, 20);
            this.textBoxInterval.TabIndex = 6;
            this.textBoxInterval.Text = "1";
            this.textBoxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelInterval
            // 
            this.panelInterval.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelInterval.Controls.Add(this.labelFilesInterval);
            this.panelInterval.Controls.Add(this.textBoxInterval);
            this.panelInterval.Location = new System.Drawing.Point(43, 58);
            this.panelInterval.Name = "panelInterval";
            this.panelInterval.Size = new System.Drawing.Size(186, 26);
            this.panelInterval.TabIndex = 7;
            // 
            // labelFilesInterval
            // 
            this.labelFilesInterval.AutoSize = true;
            this.labelFilesInterval.Location = new System.Drawing.Point(2, 0);
            this.labelFilesInterval.Name = "labelFilesInterval";
            this.labelFilesInterval.Size = new System.Drawing.Size(124, 13);
            this.labelFilesInterval.TabIndex = 8;
            this.labelFilesInterval.Text = "Files start minus interval: ";
            // 
            // howManyTimes
            // 
            this.howManyTimes.Location = new System.Drawing.Point(125, 105);
            this.howManyTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.howManyTimes.Name = "howManyTimes";
            this.howManyTimes.Size = new System.Drawing.Size(120, 20);
            this.howManyTimes.TabIndex = 8;
            this.howManyTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(272, 289);
            this.Controls.Add(this.howManyTimes);
            this.Controls.Add(this.panelInterval);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStatusChanging);
            this.Controls.Add(this.labMedical);
            this.Controls.Add(this.btnUploadSession);
            this.Controls.Add(this.comboBoxServers);
            this.Controls.Add(this.lblChooseServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Sessions Uploder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelInterval.ResumeLayout(false);
            this.panelInterval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.howManyTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseServer;
        private System.Windows.Forms.ComboBox comboBoxServers;
        private System.Windows.Forms.Button btnUploadSession;
        private System.Windows.Forms.Label lblStatusChanging;
        private System.Windows.Forms.Label labMedical;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Panel panelInterval;
        private System.Windows.Forms.Label labelFilesInterval;
        private System.Windows.Forms.NumericUpDown howManyTimes;
    }
}

