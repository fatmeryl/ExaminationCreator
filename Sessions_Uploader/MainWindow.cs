using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessions_Uploader.Config;

namespace Sessions_Uploader
{
    public partial class MainWindow : Form
    {
        internal const string ExaminationCreator = "Examination Creator";

        private readonly string configPath;

        private readonly IServerConfigurationProvider serverConfigurationProvider;

        internal string tempDirectory;

        internal Dictionary<string, string> listOfServers;

        private TimeSpan calculatedInterval;

        private MessageGenerator msgGenerator;

        private Validator validator;

        public MainWindow()
        {
            InitializeComponent();
            tempDirectory = tempFolderTekstBox.Text + Path.DirectorySeparatorChar;
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\servers.json");
            serverConfigurationProvider = new ServerConfigurationFromConfigProvider(configPath);
            listOfServers = serverConfigurationProvider.GetServerConfiguration();

            foreach (var key in listOfServers.Keys)
            {
                comboBoxServers.Items.Add(key);
            }

            msgGenerator = new MessageGenerator();
            validator = new Validator(
                directorySourceTextBox,
                directoryOutputTextBox,
                tempFolderTekstBox,
                comboBoxServers,
                listOfServers,
                tempDirectory);
        }

        private void btnUploadSession_Click(object sender, EventArgs e)
        {
            (State validation, Control control) = validator.Validate();
            if (validation != State.Ok)
            {
                msgGenerator.GenerateMessage(validation, control);
                return;
            }

            var logFilePath = Path.Combine(
                tempDirectory,
                $"Session Uploader Log {DateTime.Now:yyyy-MM-dd HHmmss}.txt");
            using (var writer = File.CreateText(logFilePath))
            {
                for (int i = 1; i <= howManyTimes.Value; i++)
                {
                    writer.WriteLine($"Examination no.{i}, ID = {CheckSelectedServer(listOfServers)}");

                    if (howManyTimes.Value > 1)
                    {
                        Task.Delay(1000).Wait();
                    }
                }
            }

            if (clearTempOptionCheckBox.Checked)
            {
                ClearTempDirectory();
            }

            msgGenerator.GenerateMessage(validation, control);
        }

        private void ClearTempDirectory()
        {
            var di = new DirectoryInfo(tempDirectory);
            foreach (var dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private string CheckSelectedServer(Dictionary<string, string> listOfServers)
        {
            var uploader = new Uploader(
                DateTime.Now.ToLocalTime() - calculatedInterval,
                $@"{directorySourceTextBox.Text}\",
                tempDirectory);

            listOfServers.TryGetValue(comboBoxServers.Text, out var serverPath);

            if (serverPath == ExaminationCreator)
            {
                serverPath = directoryOutputTextBox.Text;
            }

            return uploader.UploadToServer(serverPath);
        }

        private void SetTextBoxPath(ref TextBox textBox)
        {
            textBox.BackColor = Color.Empty;
            var dialogTree = new FolderBrowserDialog();
            dialogTree.SelectedPath = textBox.Text;
            if (dialogTree.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = dialogTree.SelectedPath;
            }
        }

        private void BrowseSource_Click(object sender, EventArgs e)
        {
            SetTextBoxPath(ref directorySourceTextBox);
        }

        private void BrowseOutput_Click(object sender, EventArgs e)
        {
            SetTextBoxPath(ref directoryOutputTextBox);
        }

        private void openTempBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tempDirectory))
            {
                Process.Start(tempDirectory);
            }
            else
            {
                msgGenerator.GenerateMessage(State.TempDirNotExist, tempFolderTekstBox);
            }
        }

        private TimeSpan CalculateExaminationTime(IEnumerable<string> files)
        {
            var listOfAnn = files.ToList();

            if (listOfAnn.Count() == 1)
            {
                msgGenerator.GenerateMessage(State.LessThan2AnnFiles, directorySourceTextBox);
                return new TimeSpan(0);
            }

            if (!listOfAnn.Any())
            {
                msgGenerator.GenerateMessage(State.NoAnnFiles, directorySourceTextBox);
                return new TimeSpan(0);
            }

            return GetDate(listOfAnn.Last()) - GetDate(listOfAnn.First());
        }

        private DateTime GetDate(string filename)
        {
            var ann = new SessionId(Path.GetFileNameWithoutExtension(filename));
            return DateTime.ParseExact(ann.GetDate(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }

        internal IEnumerable<string> GetAnnFilesNames()
        {
            return Directory.GetFiles(directorySourceTextBox.Text, "*", SearchOption.TopDirectoryOnly)
                .Where(s => s.EndsWith(".ann"));
        }

        private void directorySourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(directorySourceTextBox.Text))
            {
                CalculateAndEnsureIntervalIsAtLeaseOneHourLong(GetAnnFilesNames());
            }
        }

        private TimeSpan CalculateAndEnsureIntervalIsAtLeaseOneHourLong(IEnumerable<string> files)
        {
            var interval = CalculateExaminationTime(files);
            if (interval < TimeSpan.FromHours(1))
            {
                interval = TimeSpan.FromHours(1);
            }

            return calculatedInterval = interval;
        }

        private void tempFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            tempFolderTekstBox.BackColor = Color.Empty;

            tempFolderTekstBox.Enabled = tempFolderCheckBox.Checked;
        }

        private void comboBoxServers_TextChanged(object sender, EventArgs e)
        {
            OutputGroupBox.Visible = comboBoxServers.Text == ExaminationCreator;
        }

        private void openConfigBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(configPath))
            {
                Process.Start(configPath);
            }
            else
            {
                msgGenerator.GenerateMessage(State.NoConfigFile, null);
            }
        }

        private void tempFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            tempDirectory = tempFolderTekstBox.Text + Path.DirectorySeparatorChar;
        }

        private void HowManyTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}