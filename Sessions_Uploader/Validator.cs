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

        public Tuple<State, Control> Validate()
        {
            if (!Directory.Exists(directorySourceTextBox.Text))
            {
                return new Tuple<State, Control>(State.NotValidSourceDir, directorySourceTextBox);
            }

            var getAnnFilesNames = Directory.GetFiles(directorySourceTextBox.Text, "*", SearchOption.TopDirectoryOnly)
                .Where(s => s.EndsWith(".ann"));
            if (getAnnFilesNames.Count() < 2)
            {
                return new Tuple<State, Control>(State.NoAnnFiles, directorySourceTextBox);
            }

            if (string.IsNullOrEmpty(comboBoxServers.Text))
            {
                return new Tuple<State, Control>(State.NoServerSelected, comboBoxServers);
            }

            listOfServers.TryGetValue(comboBoxServers.Text, out string serverpath);

            if (serverpath == MainWindow.ExaminationCreator)
            {
                if (directoryOutputTextBox.Text == directorySourceTextBox.Text)
                {
                    return new Tuple<State, Control>(State.SourceDirEqualsOutputDir, directoryOutputTextBox);
                }

                if (!Directory.Exists(directoryOutputTextBox.Text))
                {
                    return new Tuple<State, Control>(State.NotValidOutputDir, directoryOutputTextBox);
                }

                if (!Directory.Exists(tempDirectory))
                {
                    return new Tuple<State, Control>(State.TempDirNotExist, tempFolderTekstBox);
                }
            }

            return new Tuple<State, Control>(State.Ok, null);
        }
    }
}
