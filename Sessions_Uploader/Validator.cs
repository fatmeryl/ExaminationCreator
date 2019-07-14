using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessions_Uploader.Config;

namespace Sessions_Uploader
{
    class Validator
    {
        private TextBox directorySourceTextBox;
        private TextBox directoryOutputTextBox;
        private TextBox tempFolderTekstBox;
        private ComboBox comboBoxServers;
        private Dictionary<string, string> listOfServers;
        private string tempDirectory;


        public Validator(
            TextBox directorySourceTextBox,
            TextBox directoryOutputTextBox,
            TextBox tempFolderTekstBox,
            ComboBox comboBoxServers,
            Dictionary<string, string> listOfServers,
            string tempDirectory)
        {
            this.directorySourceTextBox = directorySourceTextBox;
            this.directoryOutputTextBox = directoryOutputTextBox;
            this.tempFolderTekstBox = tempFolderTekstBox;
            this.comboBoxServers = comboBoxServers;
            this.listOfServers = listOfServers;
            this.tempDirectory = tempDirectory;
        }

        public State Validate()
        {

            if (!Directory.Exists(directorySourceTextBox.Text))
            {
                return State.NotValidSourceDir;
            }

            var getAnnFilesNames = Directory.GetFiles(directorySourceTextBox.Text, "*", SearchOption.TopDirectoryOnly)
                .Where(s => s.EndsWith(".ann"));
            if (getAnnFilesNames.Count() < 2)
            {
                return State.NoAnnFiles;
            }

            if (string.IsNullOrEmpty(comboBoxServers.Text))
            {
                return State.NoServerSelected;
            }

            listOfServers.TryGetValue(comboBoxServers.Text, out string serverpath);

            if (!Directory.Exists(serverpath) && serverpath != MainWindow.ExaminationCreator)
            {
                return State.ServerConnectionProblem;
            }

            if (serverpath == MainWindow.ExaminationCreator)
            {
                if (directoryOutputTextBox.Text == directorySourceTextBox.Text)
                {
                    return State.SourceDirEqualsOutputDir;
                }

                if (!Directory.Exists(directoryOutputTextBox.Text))
                {
                    return State.NotValidOutputDir;
                }

                if (!Directory.Exists(tempDirectory))
                {
                    return State.TempDirNotExist;
                }
            }

            return State.Ok;
        }
    }
}
