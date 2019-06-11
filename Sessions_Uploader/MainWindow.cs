using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace Sessions_Uploader
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUploadSession_Click(object sender, EventArgs e)
        {
            if (directorySourceTextBox.Text == String.Empty)
            {
                MessageBox.Show("Please enter a valid source directory");
            }
            else
            {
                for (int i = 1; i <= howManyTimes.Value; i++)
                {
                    CheckSelectedServer();
                }
                string message = "Session(s) successfully uploaded!\n";
                MessageBox.Show(message);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            string tempDirectory = @"C:\ReadyToUpload\";

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
                MessageBox.Show("No Item is Selected");
            }
            else
            {
                var uploader = new Uploader(
                    DateTime.Now.ToLocalTime() - TimeSpan.FromHours(Int32.Parse(textBoxInterval.Text)),
                    directorySourceTextBox.Text,
                    @"C:\ReadyToUpload\");

                comboBoxServers.SelectedItem = string.Empty;
                switch (comboBoxServers.SelectedItem.ToString())
                {
                    case "Examination Creator":
                        uploader.UploadToServer(directoryOutputTextBox.Text);
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
                directorySourceTextBox.Text = $@"{dialogTree.SelectedPath}\";
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

        
    }
}
