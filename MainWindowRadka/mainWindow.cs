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
        private readonly string configPath;

        private readonly IServerConfigurationProvider serverConfigurationProvider;

        private string tempDirectory;

        private Dictionary<string, string> listOfServers;

        private string calculatedInterval;

        public MainWindow()
        {
            InitializeComponent();
            tempDirectory = $@"{tempFolderTekstBox.Text}\";

            /* createDirectory nie wywala się jak katalog już jest, więc można pominąc pisanie if Dir exists */
            /* nie wiem na ile chcesz to mieć idiotoodporne, ale jak create rzuci ci wyjątkiem to chyba cały program się wysypie, bo nie masz try-catch */

            /*
			 Dodałem to aby przy 1wszym uruchomieniu stworzył się ten ten folder. W przypadku skasowania folderu przy już uruchomionym programie
             mam obsłużony ten bug w commicie 9ce26d525bf5387191957e12ab28c88e08d8d30f
			 */
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\servers.json");
            serverConfigurationProvider = new ServerConfigurationFromConfigProvider(configPath);
            listOfServers = serverConfigurationProvider.GetServerConfiguration();

			/* jest cos takiego jak AddRange, więc stawiam, że możnaby napisać:
				comboBoxServers.Items.AddRange(listOfServers.Keys)
			*/
            /*
             Nie znam tego. To tujaj sam wykombinowałem foreachem.
             AddRange bierze jako parametr tablicę objektów, musiał bym zmianiać wsztko niżej aby przrobić z Dictionary.
             Czy warto?
             */
       
				
            foreach (var key in listOfServers.Keys)
            {
                comboBoxServers.Items.Add(key);
            }
        }

        private static void MsgTempDirectoryNotExist()
        {
            MessageBox.Show(
                "Temporary directory does not exist",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

		/* tutaj to mały kod i to nie ma większego znaczenia, ale generalnie nie podoba mi się, że to sprawdza czy wszystko jest ok,
		 a do tego jeszcze wyświetla boxy, trzebaby rozdzielić odpowiedzialności najprostszy pomysł jaki przychodzi mi do głowy to zrobić enuma w stylu
			enum state {
				OK,
				NoSourceDir,
				NoAnn,
				...
			}
			zwracać wartość takiego enuma, a następnie jakaś inna metoda nazywająca się GenerateMessage dostawałaby takiego enuma i wyświetlała odpowiednie okienko
		*/

        /*
         Brzmi dla mnie jak większe zadanie, ale posiedzę nad tym i zobaczę co uda się zakodzić.
         */
        private bool ValidateControls()
        {
            if (!Directory.Exists(directorySourceTextBox.Text))
            {
                directorySourceTextBox.BackColor = Color.LightPink;
                MessageBox.Show(
                    "Please enter a valid source directory",
                    "Missing Source directory",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

			/* Na pewno < 2 ? */
            // Tak, 2 anny to minimum aby obliczyć czas interwału potrzebny do przestawienia czasu badania oraz jego ID.

            if (GetAnnFilesNames().Count() < 2)
            {
                directorySourceTextBox.BackColor = Color.LightPink;
                MessageBox.Show(
					/* generalnie zamiast pisać \n lepiej uzyc Environment.NewLine, a więc jakos tak:
						"Source directory does not contains any .ann files." + Environment.NewLine + "Please provide valid directory."
					*/
					/* brakuje kropki miedzy zdaniami */

                    // O tego nie znałem, thx. I kropkę też dostawię.
                    "Source directory does not contains any .ann files\nPlease provide valid directory.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (string.IsNullOrEmpty(comboBoxServers.Text))
            {
                MessageBox.Show(
                    "Please choose server to upload files",
                    "Missing server destination",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            string serverpath;
            listOfServers.TryGetValue(comboBoxServers.Text, out serverpath);

			/* ten string Examination Creator powinienes dac do jakiejs stałej i to jej uzywać */

            // Czy dobrze kombinuję aby zrobić z tego pole i w konstruktorze przypisać wartość?
            if (!Directory.Exists(serverpath) && serverpath != "Examination Creator")
            {
                MessageBox.Show(
                    "There was a problem with connection to selected server.\nCheck your network connection.",
                    "Connection to server problem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (serverpath == "Examination Creator")
            {
                if (directoryOutputTextBox.Text == directorySourceTextBox.Text)
                {
                    directoryOutputTextBox.BackColor = Color.LightPink;
                    MessageBox.Show(
                        "Output directory is the same as source directory",
                        "Invalid outputdirectory",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                if (!Directory.Exists(directoryOutputTextBox.Text))
                {
                    directoryOutputTextBox.BackColor = Color.LightPink;
                    MessageBox.Show(
                        "Please provide valid output directory",
                        "Missing Output directory",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
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

			/* raczej lepiej uzyć Path.Combine */
            var logFilePath = $@"{tempDirectory}\Session Uploader Log {DateTime.Now:yyyy-MM-dd HHmmss}.txt";
            using (var writer = File.CreateText(logFilePath))
            {
                for (int i = 1; i <= howManyTimes.Value; i++)
                {
                    writer.WriteLine($"Examination no.{i}, ID = {CheckSelectedServer(listOfServers)}");

                    /* po co jest ten delay tutaj? */
                    /* + tak jak napisałeś czekasz po zakończeniu ostatniego o ile jest ich wiecej niż jeden, a zatem jesli to mają być przerwy pomiędzy zadaniami to lepiej napisać if (i > 1) */

                    /*
                     W debugu to nie wyszło, ale jak odpaliłem w normalnym trybie
                     program to przy tworzeniu 2+ badań to rzucało mi Exceptionem.
                     Drugie badanie dostawało te same ID.
                     Commit a053e4e4296ca75ae160d14da629232ae600fc56, nazwa commita niestety słaba :/
                     */
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

            MessageBox.Show(
                "Session(s) successfully uploaded!\n",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
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
			/* czy te kolejne nawiasy klamrowe to pozostałośc po czymś czy są potrzebne? */

            // do skasowania, moje niedopatrzenie
            {
                var uploader = new Uploader(
                    DateTime.Now.ToLocalTime() - TimeSpan.FromHours(int.Parse(calculatedInterval)),
                    $@"{directorySourceTextBox.Text}\",
                    tempDirectory);

                listOfServers.TryGetValue(comboBoxServers.Text, out var serverPath);

                if (serverPath == "Examination Creator")
                {
                    serverPath = directoryOutputTextBox.Text;
                }

                return uploader.UploadToServer(serverPath);
            }
        }

		/* ta i następna metoda wyglądają tak samo praktycznie, fajnie by było się nie powtarzać
			można zrobić kolejną dostającą text przez refa i wywołać raz z directorySourceTextBox.Text, a drugi z directoryOutputTextBox.Text */

        /*
         To już level dla mnie zaawansowany :), ale też poczytam i sprawdzę czy uda się zakodzić.
         */
        private void BrowseSource_Click(object sender, EventArgs e)
        {
            directorySourceTextBox.BackColor = Color.Empty;
            FolderBrowserDialog dialogTree = new FolderBrowserDialog();
            dialogTree.SelectedPath = directorySourceTextBox.Text;
            if (dialogTree.ShowDialog() == DialogResult.OK)
            {
                directorySourceTextBox.Text = dialogTree.SelectedPath;
            }
        }

        private void BrowseOutput_Click(object sender, EventArgs e)
        {
            directoryOutputTextBox.BackColor = Color.Empty;
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
                Process.Start(tempDirectory);
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
                directorySourceTextBox.BackColor = Color.LightPink;
                MessageBox.Show(
                    "Source directory does not contains any .ann files\nPlease provide valid directory.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return 0;
            }

			/* dwa razy to samo, najlepiej by było dodac jakąś mała metodę w stylu:
				DateTime GetDate(string fileName) {
					var ann = Path.GetFileNameWithoutExtension(fileName);
					return DateTime.ParseExact(ann.Substring(0, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToUniversalTime()
				}
				
				i wywołać ją raz GetDate(files.First) i drugi GetDate(files.Last)
			*/
            var firstAnn = Path.GetFileNameWithoutExtension(files.First());
            var lastAnn = Path.GetFileNameWithoutExtension(files.Last());

            var firstAnnDate = DateTime.ParseExact(firstAnn.Substring(0, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
                .ToUniversalTime();
            var lastAnnDate = DateTime.ParseExact(lastAnn.Substring(0, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
                .ToUniversalTime();

			/* dlaczego zwracasz godziny, a nie po prostu timespana? */
			/* mozna po prostu napsiać
				return lastAnnDate - firstAnnDate).TotalHours;
			*/

            /*
             Nie zastanawiałem się nad tym. A może nie wiedziałem, że można.
             Czy to zadziała tak samo jak zwrócę timespana?

            Co do returna, to rzeczywiście od razu lepiej retrun //kod
             */
            var interval = (lastAnnDate - firstAnnDate).TotalHours;
            return interval;
        }

        private IEnumerable<string> GetAnnFilesNames()
        {
            try
            {
				/* można po prostu napisać
					return Directory.GetFiles(directorySourceTextBox.Text, "*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".ann")).ToList();
				*/
				/* dlaczego robisz ToList? */

                /*                 
                 Return racja, jak wyżej.

                Zwaracam listę ponieważ potem biorę z niej pierwszy i ostatni item i na podstawie ich czasów wyliczam interwał(czas trwania badania)
                 */
                var files = Directory.GetFiles(directorySourceTextBox.Text, "*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".ann")).ToList();
                return files;
            }
            /* trochę ogólny ten catch, wiesz jakie konkretnie wyjątki chcesz złapać i dlaczego moga wystąpić? */

            /*
            Chcę to łapać jeżeli user poda w source np C:, albo D:
            Wyszło przypadkiem dla własnie takich lokalizacji jako source.
            Jak podawałem foldery nie zawierające badań to program działał. 
            Rzucało tylko właśnie przy C:, D: etc jeżeli ta lokalizacja nie zawierała .ann.
            Commit 230b59f62010745c253e36cafd6c57b73c3b8e41
             */
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

			/* to trochę wraca do pytania wyzej o zwracanie timespana zamiast godzin, ale nie rozumiem dlaczego ten math.ceiling tutaj */

            /*
             Zaokrąglam interwał aby wynosił minumum 1 godzinę, dla badań gdzie wyliczony czas trwania wynosi mniej niż 1 godzinę.
             Ten program tak już został przez Tomka napisany, że trzeba było podać z palca ile trwa badanie.
             Ta wartość była odejmowana od aktualnego czasu i tak powstawał czas startu badania. Chodzi o to, aby badania nie były
             z przysłości.
             Ja sobie sam wykombiniwałem automatyczne wyliczenie interwału i zaookrąglam aby minuimum było to 1godzina, nawet
             jak badanie trwało 5minut.
             */
            return calculatedInterval = Math.Ceiling(interval).ToString();
        }

        private void tempFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
			/* można po prostu napisać:
				tempFolderTekstBox.Enabled = tempFolderCheckBox.Checked;
			*/
            
            /*
             No tak :). Properta Checked ustawia boola. 
             Wychodzi moje myślenie "łopatologiczne".
             */
            if (tempFolderCheckBox.Checked)
            {
                tempFolderTekstBox.Enabled = true;
            }
            else
            {
                tempFolderTekstBox.Enabled = false;
            }
        }

        private void comboBoxServers_TextChanged(object sender, EventArgs e)
        {
			/* mozna po prostu napisać
				OutputGroupBox.Visible = comboBoxServers.Text == "Examination Creator";
			*/
            // j.w.
            if (comboBoxServers.Text == "Examination Creator")
            {
                OutputGroupBox.Visible = true;
            }
            else
            {
                OutputGroupBox.Visible = false;
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
                /* trochę niekonsekwencja -  wcześniej w openTmp czy coś takiego miałeś to w oddzielnej metodzie */

                // Chodzi o MsgTempDirectoryNotExist() ? Jezeli tak, to zrobiłem na to metodkę, bo wykorzystuję to w 2-óch miejscach.
                MessageBox.Show(
                    "Config file does not exist",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
        }

        private void tempFolderTextBox_TextChanged(object sender, EventArgs e)
        {
			/* lepiej zamiast / uzyć Path.PathSeparator, a więc:
				tempFolderTekstBox.Text + Path.PathSeparator
			*/

            // nowość dla mnie, dzieki
            tempDirectory = $@"{tempFolderTekstBox.Text}\";
        }

        private void HowManyTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}