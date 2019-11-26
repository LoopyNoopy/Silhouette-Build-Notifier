namespace SBuildNotifierV2
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSeverPath = new System.Windows.Forms.Label();
            this.fileDialogServerPath = new System.Windows.Forms.OpenFileDialog();
            this.folderDialogServerPath = new System.Windows.Forms.FolderBrowserDialog();
            this.btnServerLocation = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.chkLBoxBranches = new System.Windows.Forms.CheckedListBox();
            this.nIcoBNotifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnStartup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(124, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title Label";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeverPath
            // 
            this.lblSeverPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeverPath.AutoSize = true;
            this.lblSeverPath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeverPath.Location = new System.Drawing.Point(133, 40);
            this.lblSeverPath.Name = "lblSeverPath";
            this.lblSeverPath.Size = new System.Drawing.Size(121, 21);
            this.lblSeverPath.TabIndex = 1;
            this.lblSeverPath.Text = "Sever path label";
            // 
            // fileDialogServerPath
            // 
            this.fileDialogServerPath.InitialDirectory = "This PC";
            this.fileDialogServerPath.Title = "Select Build Folder";
            // 
            // folderDialogServerPath
            // 
            this.folderDialogServerPath.Description = "Map the build folder to a network drive then select it here:";
            this.folderDialogServerPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderDialogServerPath.ShowNewFolderButton = false;
            // 
            // btnServerLocation
            // 
            this.btnServerLocation.AutoSize = true;
            this.btnServerLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnServerLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(206)))));
            this.btnServerLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnServerLocation.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnServerLocation.FlatAppearance.BorderSize = 0;
            this.btnServerLocation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(128)))), ((int)(((byte)(152)))));
            this.btnServerLocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(154)))), ((int)(((byte)(183)))));
            this.btnServerLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServerLocation.ForeColor = System.Drawing.Color.White;
            this.btnServerLocation.Location = new System.Drawing.Point(12, 37);
            this.btnServerLocation.Name = "btnServerLocation";
            this.btnServerLocation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnServerLocation.Size = new System.Drawing.Size(115, 29);
            this.btnServerLocation.TabIndex = 2;
            this.btnServerLocation.Text = "Change Location";
            this.btnServerLocation.UseVisualStyleBackColor = false;
            this.btnServerLocation.Click += new System.EventHandler(this.btnServerLocation_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(115, 69);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(126, 21);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Year n Date label";
            // 
            // chkLBoxBranches
            // 
            this.chkLBoxBranches.CheckOnClick = true;
            this.chkLBoxBranches.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLBoxBranches.FormattingEnabled = true;
            this.chkLBoxBranches.Location = new System.Drawing.Point(12, 93);
            this.chkLBoxBranches.Name = "chkLBoxBranches";
            this.chkLBoxBranches.Size = new System.Drawing.Size(176, 89);
            this.chkLBoxBranches.TabIndex = 4;
            this.chkLBoxBranches.SelectedIndexChanged += new System.EventHandler(this.chkLBoxBranches_SelectedIndexChanged);
            // 
            // nIcoBNotifier
            // 
            this.nIcoBNotifier.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nIcoBNotifier.BalloonTipText = "Build Notifier is still running";
            this.nIcoBNotifier.BalloonTipTitle = "Silhouette Build Notifier";
            this.nIcoBNotifier.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcoBNotifier.Icon")));
            this.nIcoBNotifier.Text = "Build Notifier";
            this.nIcoBNotifier.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nIcoBNotifier_MouseDoubleClick);
            // 
            // btnStartup
            // 
            this.btnStartup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(206)))));
            this.btnStartup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(128)))), ((int)(((byte)(152)))));
            this.btnStartup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(154)))), ((int)(((byte)(183)))));
            this.btnStartup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartup.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnStartup.ForeColor = System.Drawing.Color.White;
            this.btnStartup.Location = new System.Drawing.Point(194, 93);
            this.btnStartup.Name = "btnStartup";
            this.btnStartup.Size = new System.Drawing.Size(105, 30);
            this.btnStartup.TabIndex = 6;
            this.btnStartup.Text = "Run at startup";
            this.btnStartup.UseVisualStyleBackColor = false;
            this.btnStartup.Click += new System.EventHandler(this.btnStartup_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(357, 450);
            this.Controls.Add(this.btnStartup);
            this.Controls.Add(this.chkLBoxBranches);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSeverPath);
            this.Controls.Add(this.btnServerLocation);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Build Notifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSeverPath;
        private System.Windows.Forms.OpenFileDialog fileDialogServerPath;
        private System.Windows.Forms.FolderBrowserDialog folderDialogServerPath;
        private System.Windows.Forms.Button btnServerLocation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.CheckedListBox chkLBoxBranches;
        private System.Windows.Forms.NotifyIcon nIcoBNotifier;
        private System.Windows.Forms.Button btnStartup;
    }
}

