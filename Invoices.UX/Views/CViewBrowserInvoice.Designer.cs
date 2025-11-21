namespace Flix.UX.Views
{
    partial class CViewBrowserAppUser
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
            lstBrowser = new ListBox();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnFind = new Button();
            pnlTop = new Panel();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // lstBrowser
            // 
            lstBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstBrowser.FormattingEnabled = true;
            lstBrowser.ItemHeight = 15;
            lstBrowser.Location = new Point(12, 67);
            lstBrowser.Name = "lstBrowser";
            lstBrowser.Size = new Size(776, 364);
            lstBrowser.TabIndex = 0;
            lstBrowser.DoubleClick += DoOnAnyCommand;
            lstBrowser.KeyPress += DoOnAnyKeyPress;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(111, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(257, 23);
            txtSearch.TabIndex = 1;
            txtSearch.KeyPress += DoOnAnyKeyPress;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 23);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(94, 15);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Customer Name";
            // 
            // btnFind
            // 
            btnFind.Location = new Point(374, 19);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(75, 23);
            btnFind.TabIndex = 3;
            btnFind.Text = "Search";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += DoOnAnyCommand;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lblSearch);
            pnlTop.Controls.Add(btnFind);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 61);
            pnlTop.TabIndex = 4;
            // 
            // CViewBrowserAppUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlTop);
            Controls.Add(lstBrowser);
            Name = "CViewBrowserAppUser";
            Text = "CViewBrowserAppUser";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstBrowser;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnFind;
        private Panel pnlTop;
    }
}