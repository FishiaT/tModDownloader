namespace tModDownloader
{
    partial class DownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusLabel = new Label();
            progressBar1 = new ProgressBar();
            progressLabel = new Label();
            label1 = new Label();
            logRTB = new RichTextBox();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(14, 10);
            statusLabel.Margin = new Padding(4, 0, 4, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(151, 15);
            statusLabel.TabIndex = 0;
            statusLabel.Text = "Downloading, please wait...";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(14, 29);
            progressBar1.Margin = new Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(505, 27);
            progressBar1.TabIndex = 1;
            // 
            // progressLabel
            // 
            progressLabel.AutoSize = true;
            progressLabel.Location = new Point(14, 59);
            progressLabel.Margin = new Padding(4, 0, 4, 0);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new Size(75, 15);
            progressLabel.TabIndex = 2;
            progressLabel.Text = "Progress: 0/0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 87);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 4;
            label1.Text = "Logs";
            // 
            // logRTB
            // 
            logRTB.Location = new Point(14, 105);
            logRTB.Margin = new Padding(4, 3, 4, 3);
            logRTB.Name = "logRTB";
            logRTB.ReadOnly = true;
            logRTB.Size = new Size(504, 115);
            logRTB.TabIndex = 5;
            logRTB.Text = "";
            // 
            // DownloadForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 236);
            Controls.Add(logRTB);
            Controls.Add(label1);
            Controls.Add(progressLabel);
            Controls.Add(progressBar1);
            Controls.Add(statusLabel);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DownloadForm";
            Text = "Downloading...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label statusLabel;
        private ProgressBar progressBar1;
        private Label progressLabel;
        private Label label1;
        private RichTextBox logRTB;
    }
}