namespace tModDownloader
{
    partial class ModBrowser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nextBtn = new Button();
            previousBtn = new Button();
            pageLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            tmlVersionComboBox = new ComboBox();
            progressBar = new ProgressBar();
            statusLabel = new Label();
            modsList = new FlowLayoutPanel();
            selectedModsLabel = new Label();
            downloadButton = new Button();
            label3 = new Label();
            searchTextBox = new TextBox();
            searchButton = new Button();
            refreshBtn = new Button();
            SuspendLayout();
            // 
            // nextBtn
            // 
            nextBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nextBtn.Location = new Point(873, 3);
            nextBtn.Margin = new Padding(4, 3, 4, 3);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(50, 27);
            nextBtn.TabIndex = 8;
            nextBtn.Text = ">";
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextBtn_Click;
            // 
            // previousBtn
            // 
            previousBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            previousBtn.Location = new Point(818, 3);
            previousBtn.Margin = new Padding(4, 3, 4, 3);
            previousBtn.Name = "previousBtn";
            previousBtn.Size = new Size(47, 27);
            previousBtn.TabIndex = 7;
            previousBtn.Text = "<";
            previousBtn.UseVisualStyleBackColor = true;
            previousBtn.Click += previousBtn_Click;
            // 
            // pageLabel
            // 
            pageLabel.Anchor = AnchorStyles.Top;
            pageLabel.AutoSize = true;
            pageLabel.Location = new Point(756, 9);
            pageLabel.Margin = new Padding(4, 0, 4, 0);
            pageLabel.Name = "pageLabel";
            pageLabel.Size = new Size(45, 15);
            pageLabel.TabIndex = 6;
            pageLabel.Text = "Page: 1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(204, 15);
            label1.TabIndex = 5;
            label1.Text = "tModDownloader - Version 0.0.1-beta\r\n";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(320, 9);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 10;
            label2.Text = "tModLoader Version";
            // 
            // tmlVersionComboBox
            // 
            tmlVersionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tmlVersionComboBox.FormattingEnabled = true;
            tmlVersionComboBox.Items.AddRange(new object[] { "1.4.4", "1.4.3" });
            tmlVersionComboBox.Location = new Point(450, 6);
            tmlVersionComboBox.Margin = new Padding(4, 3, 4, 3);
            tmlVersionComboBox.MaxDropDownItems = 2;
            tmlVersionComboBox.Name = "tmlVersionComboBox";
            tmlVersionComboBox.Size = new Size(140, 23);
            tmlVersionComboBox.TabIndex = 11;
            tmlVersionComboBox.SelectionChangeCommitted += tmlVersionComboBox_SelectionChangeCommitted;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            progressBar.Location = new Point(783, 492);
            progressBar.Margin = new Padding(4, 3, 4, 3);
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Maximum = 30;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(140, 19);
            progressBar.TabIndex = 12;
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Top;
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(14, 495);
            statusLabel.Margin = new Padding(4, 0, 4, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 15);
            statusLabel.TabIndex = 13;
            statusLabel.Text = "Ready";
            // 
            // modsList
            // 
            modsList.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modsList.AutoScroll = true;
            modsList.Location = new Point(14, 36);
            modsList.Margin = new Padding(4, 3, 4, 3);
            modsList.Name = "modsList";
            modsList.Size = new Size(909, 399);
            modsList.TabIndex = 14;
            // 
            // selectedModsLabel
            // 
            selectedModsLabel.AutoSize = true;
            selectedModsLabel.Location = new Point(14, 449);
            selectedModsLabel.Margin = new Padding(4, 0, 4, 0);
            selectedModsLabel.Name = "selectedModsLabel";
            selectedModsLabel.Size = new Size(96, 15);
            selectedModsLabel.TabIndex = 15;
            selectedModsLabel.Text = "Selected Mods: 0";
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(790, 443);
            downloadButton.Margin = new Padding(4, 3, 4, 3);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(133, 27);
            downloadButton.TabIndex = 16;
            downloadButton.Text = "Download Selected";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(331, 449);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 17;
            label3.Text = "Search";
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(386, 445);
            searchTextBox.Margin = new Padding(4, 3, 4, 3);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(160, 23);
            searchTextBox.TabIndex = 18;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(554, 445);
            searchButton.Margin = new Padding(4, 3, 4, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(88, 27);
            searchButton.TabIndex = 19;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(642, 6);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(75, 23);
            refreshBtn.TabIndex = 20;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // ModBrowser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(refreshBtn);
            Controls.Add(searchButton);
            Controls.Add(searchTextBox);
            Controls.Add(label3);
            Controls.Add(downloadButton);
            Controls.Add(selectedModsLabel);
            Controls.Add(modsList);
            Controls.Add(statusLabel);
            Controls.Add(progressBar);
            Controls.Add(tmlVersionComboBox);
            Controls.Add(label2);
            Controls.Add(nextBtn);
            Controls.Add(previousBtn);
            Controls.Add(pageLabel);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "ModBrowser";
            Text = "tModDownloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button nextBtn;
        private Button previousBtn;
        private Label pageLabel;
        private Label label1;
        private Label label2;
        private ComboBox tmlVersionComboBox;
        private ProgressBar progressBar;
        private Label statusLabel;
        private FlowLayoutPanel modsList;
        private Label selectedModsLabel;
        private Button downloadButton;
        private Label label3;
        private TextBox searchTextBox;
        private Button searchButton;
        private Button refreshBtn;
    }
}