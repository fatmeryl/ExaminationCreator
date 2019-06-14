using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Sessions_Uploader
{
    public partial class MainWindow : Form
    {
        string tempDirectory = @"C:\ReadyToUpload\";

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnUploadSession_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(directorySourceTextBox.Text))
            {
                MessageBox.Show("Please enter a valid source directory");
            }
            else
            {
                for (int i = 1; i <= howManyTimes.Value; i++)
                {
                    CheckSelectedServer();
                }
            }

            if (Directory.Exists(directoryOutputTextBox.Text) || comboBoxServers.SelectedItem != "Examination Creator")
            {
                MessageBox.Show("Session(s) successfully uploaded!\n");
            }

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            if (!clearTemp.Checked)
            {
                MessageBox.Show("Please select checkbox");
            }
            else
            {
                if (Directory.GetDirectories(tempDirectory).Length == 0 &&
                    Directory.GetFiles(tempDirectory, "*", SearchOption.AllDirectories).Length == 0)
                {
                    MessageBox.Show("Temp location is empty");
                }
                else
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
                    MessageBox.Show("All files has been deleted");
                }
            }
        }

        private void CheckSelectedServer()
        {
            if (string.IsNullOrEmpty(comboBoxServers.Text))
            {
                MessageBox.Show("Please choose server to upload files");
            }
            else
            {
                var uploader = new Uploader(
                    DateTime.Now.ToLocalTime() - TimeSpan.FromHours(Int32.Parse(textBoxInterval.Text)),
                    $@"{directorySourceTextBox.Text}\",
                    tempDirectory);

                comboBoxServers.SelectedItem = string.Empty;
                switch (comboBoxServers.SelectedItem.ToString())
                {
                    case "Examination Creator":
                        if (Directory.Exists(directoryOutputTextBox.Text))
                        {
                            uploader.UploadToServer(directoryOutputTextBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("Please provide output directory");
                        }
                        break;
                    case "triss-3":
                        uploader.UploadToServer(@"\\ecgfftt-13hq05.corp.medicalgorithmics.com\Servertriss-3\Root\FTP\PDA");
                        break;
                    case "triss-2":
                        uploader.UploadToServer(@"\\ecgfftt-13hq05.corp.medicalgorithmics.com\Servertriss-2\Root\FTP\PDA");
                        break;
                    case "triss-1":
                        uploader.UploadToServer(@"\\ecgfftt-13hq05.corp.medicalgorithmics.com\Servertriss-1\Root\FTP\PDA");
                        break;
                    case "yennefer-3":
                        uploader.UploadToServer(@"\\ecgfftt-13hq05.corp.medicalgorithmics.com\Serveryennefer-3\Root\FTP\PDA");
                        break;
                    case "yennefer-2":
                        uploader.UploadToServer(@"\\ecgfftt-13hq05.corp.medicalgorithmics.com\Serveryennefer-2\Root\FTP\PDA");
                        break;
                    case "yennefer-1":
                        uploader.UploadToServer(@"\\ecgfftt-13hq05.corp.medicalgorithmics.com\Serveryennefer-1\Root\FTP\PDA");
                        break;
                    case "fringilla-3":
                        uploader.UploadToServer(@"\\ecgfftt-13hq05.corp.medicalgorithmics.com\Serverfringilla-3\Root\FTP\PDA");
                        break;
                    case "fringilla-2":
                        uploader.UploadToServer(@"\\ecgfftt-13hq05.corp.medicalgorithmics.com\Serverfringilla-2\Root\FTP\PDA");
                        break;
                    case "fringilla-1":
                        uploader.UploadToServer(@"\\ecgfftt-13hq05.corp.medicalgorithmics.com\Serverfringilla-1\Root\FTP\PDA");
                        break;
                    case "klatch-1":
                        uploader.UploadToServer(@"\\ecgfftt-13hq04.corp.medicalgorithmics.com\Serverklatch-1\Root\FTP\PDA");
                        break;
                    case "klatch-2":
                        uploader.UploadToServer(@"\\ecgfftt-13hq04.corp.medicalgorithmics.com\Serverklatch-2\Root\FTP\PDA");
                        break;
                    case "uberwald-1":
                        uploader.UploadToServer(@"\\ecgfftt-13hq04.corp.medicalgorithmics.com\Serveruberwald-1\Root\FTP\PDA");
                        break;
                    case "quirm-1":
                        uploader.UploadToServer(@"\\ecgfftt-13hq04.corp.medicalgorithmics.com\Serverquirm-1\Root\FTP\PDA");
                        break;
                    default:
                        MessageBox.Show("Please choose one of the item" + Uploader.NewExaminationId);
                        break;
                }
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
        
        private void examinationCreatorSwithCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (examinationCreatorSwithCheckBox.Checked == false)
            {
                OutputGroupBox.Enabled = false;
            }

            if (examinationCreatorSwithCheckBox.Checked)
            {
                OutputGroupBox.Enabled = true;
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
                MessageBox.Show("Temporary directory does not exist", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void automaticIntervalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (automaticIntervalCheckBox.Checked)
            {
                SetAutomatedCalculatedInterval();
            }
        }
        
        private double CalculateExaminationDurationRoundedToHours()
        {
            var files = Directory.GetFiles(directorySourceTextBox.Text, "*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith((".ann"))).ToList();

            if (files.Count() < 2)
            {
                MessageBox.Show("Source directory does not contains any .ann files\nPlease provide valid directory.");
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

        private void textBoxInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit((e.KeyChar)) && !char.IsControl(e.KeyChar);
        }

        private void directorySourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(directorySourceTextBox.Text) && automaticIntervalCheckBox.Checked)
            {
                SetAutomatedCalculatedInterval();
            }
        }

        private void SetAutomatedCalculatedInterval()
        {
            var interval = CalculateExaminationDurationRoundedToHours();

            textBoxInterval.Text = (Math.Ceiling(interval).ToString());
        }
    }
}