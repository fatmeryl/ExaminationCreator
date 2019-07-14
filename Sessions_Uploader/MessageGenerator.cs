using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sessions_Uploader.Config
{
    public class MessageGenerator
    {
        private TextBox directorySourceTextBox;
        private TextBox directoryOutputTextBox;
        private TextBox tempFolderTekstBox;

        public MessageGenerator(TextBox directorySourceText, TextBox directoryOutputTextBox, TextBox tempFolderTekstBox)
        {
            this.directorySourceTextBox = directorySourceText;
            this.directoryOutputTextBox = directoryOutputTextBox;
            this.tempFolderTekstBox = tempFolderTekstBox;
        }

        public MessageGenerator()
        {
        }

        public void GenerateMessageNew(State state, Control control)
        {
            switch (state)
            {
                case State.NotValidSourceDir:
                    control.BackColor = Color.LightPink;
                    MessageBox.Show(
                        "Please enter a valid source directory",
                        "Missing Source directory",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;
                case State.NoAnnFiles:
                    directorySourceTextBox.BackColor = Color.LightPink;
                    MessageBox.Show(
                        "Source directory does not contain any .ann files" +
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
                case State.Ok:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        public void GenerateMessage(State state)
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
                case State.Ok:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}
