﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sessions_Uploader
{
    public partial class MainWindow : Form
    {
        private string tempDirectory;

        private readonly string configPath;
        
        private readonly IServerConfigurationProvider serverConfigurationProvider;

        private Dictionary<string, string> listOfServers;

        public MainWindow()
        {
            InitializeComponent();
            tempDirectory = $@"{tempFolderTekstBox.Text}\";

            configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\servers.json");
            serverConfigurationProvider = new ServerConfigurationFromConfigProvider(configPath);
            listOfServers = serverConfigurationProvider.GetServerConfiguration();
            
            foreach (var key in listOfServers.Keys)
            {
                comboBoxServers.Items.Add(key);
            }
        }

        private bool ValidateContols()
        {
            if (!Directory.Exists(directorySourceTextBox.Text))
            {
                MessageBox.Show("Please enter a valid source directory","Missing Source directory",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(comboBoxServers.Text))
            {
                MessageBox.Show("Please choose server to upload files",
                    "Missing server destination",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            string serverpath;
            listOfServers.TryGetValue((comboBoxServers.Text), out serverpath);

            if (!Directory.Exists(serverpath) && serverpath != "Examination Creator")
            {
                MessageBox.Show("There was a problem with connection to selected server." +
                                "\nCheck your network connection.",
                    "Connection to server problem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (serverpath == "Examination Creator")
            {
                if (!Directory.Exists(directoryOutputTextBox.Text))
                {
                    MessageBox.Show("Please provide valid output directory",
                        "Missing Source directory",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    return false;
                }
            }
            return true;
        }

        private void btnUploadSession_Click(object sender, EventArgs e)
        {
            if (!ValidateContols())
            {
                return;
            }

            for (int i = 1; i <= howManyTimes.Value; i++)
            {
                CheckSelectedServer(listOfServers);

                if (howManyTimes.Value > 1)
                {
                    Task.Delay(1000).Wait();
                }
            }

            if (clearTempOptionCheckBox.Checked)
            {
                ClearTempDirectory();
            }

            MessageBox.Show("Session(s) successfully uploaded!\n",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

        private void ClearTempDirectory()
        {
            DirectoryInfo di = new DirectoryInfo(tempDirectory);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            if (!clearTemp.Checked)
            {
                MessageBox.Show("Please select checkbox",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
            else
            {
                if (!Directory.Exists(tempDirectory))
                {
                    MsgTempDirectoryNotExist();
                    return;
                }

                if (Directory.GetFiles(tempDirectory, "*", SearchOption.AllDirectories).Length == 0)
                {
                    MessageBox.Show("Temporary location is empty",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                }
                else
                {
                    ClearTempDirectory();
                    MessageBox.Show("All files has been deleted",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }
        }

        private static void MsgTempDirectoryNotExist()
        {
            MessageBox.Show("Temporary directory does not exist",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

        private void CheckSelectedServer(Dictionary<string, string> ListOfServers)
        {
            {
                var uploader = new Uploader(
                    DateTime.Now.ToLocalTime() - TimeSpan.FromHours(Int32.Parse(textBoxInterval.Text)),
                    $@"{directorySourceTextBox.Text}\",
                    tempDirectory);

                string serverPath;
                ListOfServers.TryGetValue(comboBoxServers.Text, out serverPath);

                if (serverPath == "Examination Creator")
                {
                    serverPath = directoryOutputTextBox.Text;
                }

                uploader.UploadToServer(serverPath);
            }
        }

        private void BrowseSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialogTree = new FolderBrowserDialog();
            dialogTree.SelectedPath = directorySourceTextBox.Text;
            if (dialogTree.ShowDialog() == DialogResult.OK)
            {
                directorySourceTextBox.Text = dialogTree.SelectedPath;
            }
        }

        private void BrowseOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialogTree = new FolderBrowserDialog();
            dialogTree.SelectedPath = directoryOutputTextBox.Text;
            if (dialogTree.ShowDialog() == DialogResult.OK)
            {
                directoryOutputTextBox.Text = dialogTree.SelectedPath;
            }
        }

        private void openTempBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tempDirectory))
            {
                System.Diagnostics.Process.Start(tempDirectory);
            }
            else
            {
                MsgTempDirectoryNotExist();
            }
        }

        private double CalculateExaminationDurationRoundedToHours(IEnumerable<string> files)
        {
            if (files.Count() < 2)
            {
                MessageBox.Show("Source directory does not contains any .ann files\nPlease provide valid directory.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return 0;
            }

            var firstAnn = Path.GetFileNameWithoutExtension(files.First());
            var lastAnn = Path.GetFileNameWithoutExtension(files.Last());

            var firstAnnDate = DateTime.ParseExact(firstAnn.Substring(0, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
                .ToUniversalTime();
            var lastAnnDate = DateTime.ParseExact(lastAnn.Substring(0, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
                .ToUniversalTime();

            var interval = (lastAnnDate - firstAnnDate).TotalHours;
            return interval;
        }

        private IEnumerable<string> GetAnnFilesNames()
        {
            var files = Directory.GetFiles(directorySourceTextBox.Text, "*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith((".ann"))).ToList();
            return files;
        }

        private void automaticIntervalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (automaticIntervalCheckBox.Checked)
            {
                SetAutomatedCalculatedInterval(GetAnnFilesNames());
            }
        }

        private void directorySourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(directorySourceTextBox.Text) && automaticIntervalCheckBox.Checked)
            {
                SetAutomatedCalculatedInterval(GetAnnFilesNames());
            }
        }

        private void SetAutomatedCalculatedInterval(IEnumerable<string> files)
        {
            var interval = CalculateExaminationDurationRoundedToHours(files);

            textBoxInterval.Text = (Math.Ceiling(interval).ToString());
        }

        private void tempFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (tempFolderCheckBox.Checked)
            {
                tempFolderTekstBox.Enabled = true;
            }
            else
            {
                tempFolderTekstBox.Enabled = false;
            }
        }

        private void textBoxInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit((e.KeyChar)) && !char.IsControl(e.KeyChar);
        }

        private void comboBoxServers_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxServers.Text == "Examination Creator")
            {
                OutputGroupBox.Enabled = true;
            }
            else
            {
                OutputGroupBox.Enabled = false;
            }
        }

        private void openConfigBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(configPath))
            {
                Process.Start(configPath);
            }
            else
            {
                MessageBox.Show("Config file does not exist",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
        }

        private void tempFolderTekstBox_TextChanged(object sender, EventArgs e)
        {
            tempDirectory = $@"{tempFolderTekstBox.Text}\";
        }
    }
}