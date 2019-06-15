using System;
using System.Collections.Generic;
using System.Data;
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

        public MainWindow()
        {
            InitializeComponent();
            tempDirectory = $@"{tempFolderTekstBox.Text}\";
        }

        private void btnUploadSession_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(directorySourceTextBox.Text))
            {
                MessageBox.Show("Please enter a valid source directory");
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(comboBoxServers.Text))
                {
                    MessageBox.Show("Please choose server to upload files");
                    return;
                }
                else
                {
                    for (int i = 1; i <= howManyTimes.Value; i++)
                    {
                        CheckSelectedServer();

                        if (howManyTimes.Value > 1)
                        {
                            Task.Delay(1000).Wait();
                        }
                    }
                }
            }

            if (clearTempOptionCheckBox.Checked)
            {
                ClearTempDirectory();
            }

            if (Directory.Exists(directoryOutputTextBox.Text)
                || (comboBoxServers.SelectedItem != "Examination Creator"
                 && comboBoxServers.SelectedItem != null ))
            {
                MessageBox.Show("Session(s) successfully uploaded!\n");
            }
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
                MessageBox.Show("Please select checkbox");
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
                    MessageBox.Show("Temporary location is empty");
                }
                else
                {
                    ClearTempDirectory();
                    MessageBox.Show("All files has been deleted");
                }
            }
        }

        private static void MsgTempDirectoryNotExist()
        {
            MessageBox.Show("Temporary directory does not exist", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void CheckSelectedServer()
        {

            {
                var uploader = new Uploader(
                    DateTime.Now.ToLocalTime() - TimeSpan.FromHours(Int32.Parse(textBoxInterval.Text)),
                    $@"{directorySourceTextBox.Text}\",
                    tempDirectory);

                //comboBoxServers.SelectedItem = string.Empty;
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
    }
}