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

namespace Sessions_Uploader
{
    public partial class MainWindow : Form
    {
        private const string ExaminationCreator = "Examination Creator";

        private readonly string configPath;

        private readonly IServerConfigurationProvider serverConfigurationProvider;

        private string tempDirectory;

        private Dictionary<string, string> listOfServers;

        private string calculatedInterval;

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
        }

        private void GenerateMessage(State state)
        {
            switch (state)
            {
                case State.NotValidSourceDir:
                    directorySourceTextBox.BackColor = Color.LightPink;
                    MessageBox.Show(
                        "Please enter a valid source directory",
                        "Missing Source directory",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;
                case State.NoAnnFiles:
                    directorySourceTextBox.BackColor = Color.LightPink;
                    MessageBox.Show(
                        "Source directory does not contains any .ann files" +
                        Environment.NewLine + "Please provide valid directory.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    break;
                case State.NoServerSelected:
                    MessageBox.Show(
                        "Please choose server to upload files",
                        "Missing server destination",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    break;
                case State.ServerConnectionProblem:
                    MessageBox.Show(
                        "There was a problem with connection to selected server." +
                        Environment.NewLine + "Check your network connection.",
                        "Connection to server problem",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    break;
                case State.SourceDirEqualsOutputDir:
                    directoryOutputTextBox.BackColor = Color.LightPink;
                    MessageBox.Show(
                        "Output directory is the same as source directory",
                        "Invalid outputdirectory",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
                case State.NotValidOutputDir:
                    directoryOutputTextBox.BackColor = Color.LightPink;
                    MessageBox.Show(
                    "Please provide valid output directory",
                    "Missing Output directory",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                    break;
                case State.TempDirNotExist:
                    tempFolderTekstBox.BackColor = Color.LightPink;
                    MessageBox.Show(
                        "Temporary directory does not exist",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    break;
                case State.SuccesfulUpload:
                    MessageBox.Show(
                        "Session(s) successfully uploaded!",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    break;
                case State.LessThan2AnnFiles:
                    directorySourceTextBox.BackColor = Color.LightPink;
                    MessageBox.Show(
                        "Source directory contains less than two .ann files" +
                        Environment.NewLine + "Please provide examination with 2 or more .ann files.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    break;
                case State.NoConfigFile:
                    MessageBox.Show(
                        "Config file does not exist",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private bool ValidateControls()
        {
            if (!Directory.Exists(directorySourceTextBox.Text))
            {
                GenerateMessage(State.NotValidSourceDir);
                return false;
            }

            if (GetAnnFilesNames().Count() < 2)
            {
                GenerateMessage(State.NoAnnFiles);
                return false;
            }

            if (string.IsNullOrEmpty(comboBoxServers.Text))
            {
                GenerateMessage(State.NoServerSelected);
                return false;
            }

            listOfServers.TryGetValue(comboBoxServers.Text, out string serverpath);

            if (!Directory.Exists(serverpath) && serverpath != ExaminationCreator)
            {
                GenerateMessage(State.ServerConnectionProblem);
                return false;
            }

            if (serverpath == ExaminationCreator)
            {
                if (directoryOutputTextBox.Text == directorySourceTextBox.Text)
                {
                    GenerateMessage(State.SourceDirEqualsOutputDir);
                    return false;
                }

                if (!Directory.Exists(directoryOutputTextBox.Text))
                {
                    GenerateMessage(State.NotValidOutputDir);
                    return false;
                }

                if (!Directory.Exists(tempDirectory))
                {
                    GenerateMessage(State.TempDirNotExist);
                    return false;
                }
            }

            return true;
        }

        private void btnUploadSession_Click(object sender, EventArgs e)
        {
            if (!ValidateControls())
            {
                return;
            }

            var logFilePath = Path.Combine(tempDirectory,
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

            GenerateMessage(State.SuccesfulUpload);
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
                DateTime.Now.ToLocalTime() - TimeSpan.FromHours(int.Parse(calculatedInterval)),
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
            FolderBrowserDialog dialogTree = new FolderBrowserDialog();
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
                GenerateMessage(State.TempDirNotExist);
            }
        }

        private double CalculateExaminationDurationRoundedToHours(IEnumerable<string> files)
        {
            var listOfAnn = files.ToList();

            if (listOfAnn.Count() == 1)
            {
                GenerateMessage(State.LessThan2AnnFiles);
                return 0;
            }

            if (!listOfAnn.Any())
            {
                GenerateMessage(State.NoAnnFiles);
                return 0;
            }

            return (GetDate(listOfAnn.Last()) - GetDate(listOfAnn.First())).TotalHours;
        }

        private DateTime GetDate(string filename)
        {
            var ann = new SessionId(Path.GetFileNameWithoutExtension(filename));
            return DateTime.ParseExact(ann.GetDate(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }

        private IEnumerable<string> GetAnnFilesNames()
        {
            try
            {
                return Directory.GetFiles(directorySourceTextBox.Text, "*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".ann"));
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        private void directorySourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(directorySourceTextBox.Text))
            {
                SetAutomatedCalculatedInterval(GetAnnFilesNames());
            }
        }

        private string SetAutomatedCalculatedInterval(IEnumerable<string> files)
        {
            var interval = CalculateExaminationDurationRoundedToHours(files);

            return calculatedInterval = Math.Ceiling(interval).ToString();
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
                GenerateMessage(State.NoConfigFile);
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