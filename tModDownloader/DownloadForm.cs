using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace tModDownloader
{
    public partial class DownloadForm : Form
    {
        string currentDir = Environment.CurrentDirectory;

        public DownloadForm(string saveDirectory)
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Style = ProgressBarStyle.Blocks;
            InitiateDownload(saveDirectory);
        }

        private async void InitiateDownload(string saveDirectory)
        {
            var totalMods = Config.selectedMods.Count;
            var downloaded = 0;
            var percentPerMods = 100 / totalMods;
            var currentDir = Environment.CurrentDirectory;
            logRTB.Text += "Save Directory: " + saveDirectory + "\n";
            foreach (ModItem item in Config.selectedMods)
            {
                progressLabel.Text = downloaded + "/" + totalMods + " downloaded.";
                logRTB.Text += "Downloading mod " + item.Title + "...\n";
                string cliargs = "+login anonymous +workshop_download_item 1281930 " + item.ID + " +exit";
                Process scmd = new Process();
                scmd.StartInfo.FileName = Path.Combine(currentDir, "steamcmd", "steamcmd.exe");
                scmd.StartInfo.Arguments = cliargs;
                scmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                scmd.StartInfo.CreateNoWindow = true;
                scmd.Start();
                await scmd.WaitForExitAsync();
                if (scmd.ExitCode == 0)
                {
                    downloaded += 1;
                    progressBar1.Value += percentPerMods;
                }
                else
                {
                    MessageBox.Show("An error occured while trying to download " + item.Title + ". Aborting...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            if (downloaded == totalMods)
            {
                logRTB.Text += "Copying mod files to save directory...\n";
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 50;
                var workshopDir = Path.Combine(currentDir, "steamcmd", "steamapps", "workshop", "content", "1281930");
                foreach(string dir in Directory.GetDirectories(workshopDir))
                {
                    var modDir = Path.Combine(workshopDir, dir);
                    List<float> verList = new List<float>();
                    foreach(string i in Directory.GetDirectories(modDir))
                    {
                        verList.Add(float.Parse(new DirectoryInfo(i).Name));
                    }
                    Console.WriteLine(verList.Max().ToString());
                    var realModDir = Path.Combine(workshopDir, dir, verList.Max().ToString());
                    foreach(string file in Directory.GetFiles(realModDir, "*.tmod"))
                    {
                        logRTB.Text += "Copying " + Path.GetFileName(file) + " (" + verList.Max().ToString() + ")...\n";
                        File.Copy(file, Path.Combine(saveDirectory, Path.GetFileName(file)));
                    }
                }
                logRTB.Text += "Done.\nYou may now close this window.";
                statusLabel.Text = "You may now close this window.";
            }
        }
    }
}
