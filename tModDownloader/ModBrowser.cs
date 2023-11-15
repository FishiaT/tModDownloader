using HtmlAgilityPack;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;

namespace tModDownloader
{
    public partial class ModBrowser : Form
    {
        int currentPage = 1;

        string previousSearchKeyword = "";

        Dictionary<String, List<ModItem>> pagedMods = new Dictionary<String, List<ModItem>>();

        Dictionary<String, List<ModItem>> searchPagedMods = new Dictionary<String, List<ModItem>>();

        public ModBrowser()
        {
            InitializeComponent();
            tmlVersionComboBox.SelectedIndex = 0;
            Label updatingText = new Label();
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 0;
            progressBar.Maximum = 100;
            UpdateModList();
        }

        private void UpdateModList(string searchKeyword = "")
        {
            if (pagedMods.ContainsKey("page_" + currentPage) && searchKeyword.Equals(""))
            {
                DisplayEntries();
                return;
            }
            if (searchPagedMods.ContainsKey("page_" + currentPage) && !(searchKeyword.Equals("")) && searchKeyword.Equals(previousSearchKeyword))
            {
                DisplayEntries();
                return;
            }

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(delegate (object sender, RunWorkerCompletedEventArgs e)
            {
                previousSearchKeyword = searchKeyword;
                DisplayEntries();
                statusLabel.Text = "Ready";
                progressBar.Value = 0;
            });
            worker.DoWork += new DoWorkEventHandler(delegate (Object sender, DoWorkEventArgs args)
            {
                List<ModItem> mods = new List<ModItem>();
                string queryURL = @"https://steamcommunity.com/workshop/browse/?appid=1281930&searchtext=" + searchKeyword + "&childpublishedfileid=0&browsesort=trend&section=readytouseitems&requiredtags%5B0%5D=" + tmlVersionComboBox.GetItemText(tmlVersionComboBox.SelectedItem) + "&created_date_range_filter_start=0&created_date_range_filter_end=0&updated_date_range_filter_start=0&updated_date_range_filter_end=0&actualsort=trend&p=" + currentPage;
                var data = new HtmlWeb().Load(queryURL);
                string initialPageData = "";
                foreach (var node in data.DocumentNode.SelectNodes("//div[@class='workshopBrowseItems']"))
                {
                    initialPageData += node.OuterHtml;
                }
                initialPageData.Replace("<div class=\"workshopBrowseItems\">", "");
                var parsedDoc = new HtmlAgilityPack.HtmlDocument();
                parsedDoc.LoadHtml(initialPageData);
                Regex regex = new Regex(@"\?id=(\d+)&");
                var totalModsToParse = parsedDoc.DocumentNode.SelectNodes("//div[@data-panel='{&quot;type&quot;:&quot;PanelGroup&quot;}']").Count;
                var percentPerMod = 100 / totalModsToParse;
                var currentIndex = 0;
                foreach (var node in parsedDoc.DocumentNode.SelectNodes("//div[@data-panel='{&quot;type&quot;:&quot;PanelGroup&quot;}']"))
                {
                    statusLabel.Text = "Updating...";
                    currentIndex += 1;
                    progressBar.Value += percentPerMod;
                    ModItem modItem = new ModItem(null, null, null, null);
                    foreach (var childNode in node.ChildNodes)
                    {
                        if (childNode.Name == "a")
                        {
                            var href = childNode.GetAttributeValue("href", null);
                            if (href != null)
                            {
                                HtmlWeb tempWeb = new HtmlWeb();
                                modItem.SteamURL = href;
                                var itemPage = tempWeb.Load(href);
                                modItem.Title = itemPage.DocumentNode.SelectSingleNode("//head/title").InnerHtml.Trim().Replace("Steam Workshop::", "");
                                Match match = regex.Match(href);
                                if (match.Success)
                                {
                                    string id = match.Groups[1].Value;
                                    modItem.ID = id;
                                }
                                var authorNode = itemPage.DocumentNode.SelectSingleNode("//div[@class='rightDetailsBlock']//a[@class='friendBlockLinkOverlay']");
                                var authorUrl = authorNode.Attributes["href"].Value;
                                modItem.AuthorURL = authorUrl;
                                modItem.AuthorName = tempWeb.Load(authorUrl).DocumentNode.SelectSingleNode("//head/title").InnerHtml.Trim().Replace("Steam Community :: ", "");
                            }
                        }
                    }
                    var img = node.SelectSingleNode("./a/div/img");
                    var src = img.GetAttributeValue("src", null);
                    if (src != null)
                    {
                        Image origIcon = Image.FromStream(new MemoryStream(new WebClient().DownloadData(src)));
                        modItem.Icon = (Image)(new Bitmap(origIcon, new Size(64, 61)));
                    }
                    mods.Add(modItem);
                }

                if (searchKeyword.Equals(""))
                {
                    pagedMods.Add("page_" + currentPage, mods);
                }
                else
                {
                    searchPagedMods.Add("page_" + currentPage, mods);
                }
            });
            worker.RunWorkerAsync();
        }

        private void DisplayEntries()
        {
            selectedModsLabel.Text = "Selected Mods: " + Config.selectedMods.Count;
            modsList.Controls.Clear();
            List<ModItem> modList;
            if (!(searchTextBox.Text.Equals("")))
            {
                modList = searchPagedMods.GetValueOrDefault("page_" + currentPage);
            }
            else
            {
                modList = pagedMods.GetValueOrDefault("page_" + currentPage);
            }
            foreach (ModItem item in modList)
            {
                Panel modPanel = new Panel();
                modPanel.Size = new Size(773, 67);
                PictureBox modIcon = new PictureBox();
                modIcon.Size = new Size(64, 61);
                modIcon.Image = item.Icon;
                Label modTitle = new Label();
                modTitle.Text = item.Title;
                modTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
                modTitle.Location = new Point(73, 3);
                modTitle.AutoSize = true;
                Label modAuthor = new Label();
                modAuthor.Location = new Point(73, 37);
                modAuthor.AutoSize = true;
                modAuthor.Text = "By " + item.AuthorName;
                CheckBox download = new CheckBox();
                download.AutoSize = true;
                download.Location = new Point(675, 11);
                download.Text = "Download";
                download.CheckedChanged += new EventHandler(delegate (Object sender, EventArgs e)
                {
                    if (download.Checked == true)
                    {
                        Config.selectedMods.Add(item);
                    }
                    else
                    {
                        Config.selectedMods.Remove(item);
                    }
                    selectedModsLabel.Text = "Selected Mods: " + Config.selectedMods.Count;
                });
                if (Config.selectedMods.Contains(item))
                {
                    download.Checked = true;
                }
                else
                {
                    download.Checked = false;
                }
                Button moreInfoButton = new Button();
                moreInfoButton.Location = new Point(674, 32);
                moreInfoButton.Text = "More Info";
                modPanel.Controls.Add(modIcon);
                modPanel.Controls.Add(modTitle);
                modPanel.Controls.Add(modAuthor);
                modPanel.Controls.Add(download);
                modPanel.Controls.Add(moreInfoButton);
                modsList.Controls.Add(modPanel);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            currentPage += 1;
            pageLabel.Text = "Page: " + currentPage;
            UpdateModList(searchTextBox.Text);
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            if (!(currentPage - 1 < 1))
            {
                currentPage -= 1;
                pageLabel.Text = "Page: " + currentPage;
                UpdateModList(searchTextBox.Text);
            }
        }

        private void tmlVersionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateModList(searchTextBox.Text);
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (Config.selectedMods.Count < 1)
            {
                MessageBox.Show("No mods selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var currentDir = Environment.CurrentDirectory;
            if (!(Directory.Exists(Path.Combine(currentDir, "steamcmd"))) || !(File.Exists(Path.Combine(currentDir, "steamcmd", "steamcmd.exe"))))
            {
                MessageBox.Show("SteamCMD executable not found, cannot download selected mods.\n\nPlease manually download SteamCMD from Valve Developer Community and put it into \'steamcmd\' folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                CommonOpenFileDialog saveDir = new CommonOpenFileDialog();
                saveDir.InitialDirectory = "C:/";
                saveDir.IsFolderPicker = true;
                saveDir.Multiselect = false;
                saveDir.Title = "Select directory to save mods.";
                if (saveDir.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    new DownloadForm(saveDir.FileName).Show();
                }
                else
                {
                    MessageBox.Show("No directory selected, cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            UpdateModList(searchTextBox.Text);
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            pagedMods.Remove("page_" + currentPage);
            UpdateModList();
        }
    }
}