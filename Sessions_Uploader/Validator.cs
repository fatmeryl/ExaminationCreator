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
            TextBox directorySourceTextBox;
            TextBox directoryOutputTextBox;
            TextBox tempFolderTekstBox;
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
        


        public bool ValidateControls()
        {
            var msgGenerator = new MessageGenerator(directorySourceTextBox, directoryOutputTextBox, tempFolderTekstBox);

            if (!Directory.Exists(directorySourceTextBox.Text))
            {
                msgGenerator.GenerateMessage(State.NotValidSourceDir);
                return false;
            }

            var getAnnFilesNames = Directory.GetFiles(directorySourceTextBox.Text, "*", SearchOption.TopDirectoryOnly)
                .Where(s => s.EndsWith(".ann"));
            if (getAnnFilesNames.Count() < 2)
            {
                msgGenerator.GenerateMessage(State.NoAnnFiles);
                return false;
            }

            if (string.IsNullOrEmpty(comboBoxServers.Text))
            {
                msgGenerator.GenerateMessage(State.NoServerSelected);
                return false;
            }

            listOfServers.TryGetValue(comboBoxServers.Text, out string serverpath);

            if (!Directory.Exists(serverpath) && serverpath != MainWindow.ExaminationCreator)
            {
                msgGenerator.GenerateMessage(State.ServerConnectionProblem);
                return false;
            }

            if (serverpath == MainWindow.ExaminationCreator)
            {
                if (directoryOutputTextBox.Text == directorySourceTextBox.Text)
                {
                    msgGenerator.GenerateMessage(State.SourceDirEqualsOutputDir);
                    return false;
                }

                if (!Directory.Exists(directoryOutputTextBox.Text))
                {
                    msgGenerator.GenerateMessage(State.NotValidOutputDir);
                    return false;
                }

                if (!Directory.Exists(tempDirectory))
                {
                    msgGenerator.GenerateMessage(State.TempDirNotExist);
                    return false;
                }
            }

            return true;
        }
    }
}
