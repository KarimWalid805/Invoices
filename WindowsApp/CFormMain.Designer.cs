namespace WindowsApp
{
    partial class CFormMain
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
            mnuMain = new MenuStrip();
            mnuMasterDetail = new ToolStripMenuItem();
            mnuAppUsers = new ToolStripMenuItem();
            mnuGenres = new ToolStripMenuItem();
            tablesToolStripMenuItem = new ToolStripMenuItem();
            mnuSubscriptionPlans = new ToolStripMenuItem();
            mnuMovies = new ToolStripMenuItem();
            mnuMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.Items.AddRange(new ToolStripItem[] { mnuMasterDetail, tablesToolStripMenuItem });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Size = new Size(800, 24);
            mnuMain.TabIndex = 3;
            mnuMain.Text = "menuStrip1";
            // 
            // mnuMasterDetail
            // 
            mnuMasterDetail.DropDownItems.AddRange(new ToolStripItem[] { mnuAppUsers, mnuGenres });
            mnuMasterDetail.Name = "mnuMasterDetail";
            mnuMasterDetail.Size = new Size(55, 20);
            mnuMasterDetail.Text = "Master";
            // 
            // mnuAppUsers
            // 
            mnuAppUsers.Name = "mnuAppUsers";
            mnuAppUsers.Size = new Size(230, 22);
            mnuAppUsers.Text = "Application Users and Movies";
            mnuAppUsers.Click += DoOnAnyCommand;
            // 
            // mnuGenres
            // 
            mnuGenres.Name = "mnuGenres";
            mnuGenres.Size = new Size(230, 22);
            mnuGenres.Text = "Movie Genres";
            mnuGenres.Click += DoOnAnyCommand;
            // 
            // tablesToolStripMenuItem
            // 
            tablesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuSubscriptionPlans, mnuMovies });
            tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            tablesToolStripMenuItem.Size = new Size(52, 20);
            tablesToolStripMenuItem.Text = "Tables";
            // 
            // mnuSubscriptionPlans
            // 
            mnuSubscriptionPlans.Name = "mnuSubscriptionPlans";
            mnuSubscriptionPlans.Size = new Size(171, 22);
            mnuSubscriptionPlans.Text = "Subscription Plans";
            mnuSubscriptionPlans.Click += DoOnAnyCommand;
            // 
            // mnuMovies
            // 
            mnuMovies.Name = "mnuMovies";
            mnuMovies.Size = new Size(171, 22);
            mnuMovies.Text = "Movies";
            mnuMovies.Click += DoOnAnyCommand;
            // 
            // CFormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mnuMain);
            IsMdiContainer = true;
            MainMenuStrip = mnuMain;
            Name = "CFormMain";
            Text = "BLASLGFMQAWETgf";
            WindowState = FormWindowState.Maximized;
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuMasterDetail;
        private ToolStripMenuItem mnuAppUsers;
        private ToolStripMenuItem tablesToolStripMenuItem;
        private ToolStripMenuItem mnuSubscriptionPlans;
        private ToolStripMenuItem mnuMovies;
        private ToolStripMenuItem mnuGenres;
    }
}