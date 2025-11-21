namespace Invoices.UX.Views
{
    partial class CViewEntityInvoice
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
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblUserMovies = new Label();
            dgvDetails = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(48, 15);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(64, 15);
            lblFullName.TabIndex = 17;
            lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(118, 12);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(326, 23);
            txtFullName.TabIndex = 13;
            // 
            // lblUserMovies
            // 
            lblUserMovies.AutoSize = true;
            lblUserMovies.Location = new Point(118, 118);
            lblUserMovies.Name = "lblUserMovies";
            lblUserMovies.Size = new Size(50, 15);
            lblUserMovies.TabIndex = 22;
            lblUserMovies.Text = "Invoices";
            // 
            // dgvDetails
            // 
            dgvDetails.Location = new Point(118, 147);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.Size = new Size(570, 344);
            dgvDetails.TabIndex = 21;
            // 
            // CViewEntityInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 513);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblUserMovies);
            Controls.Add(dgvDetails);
            Name = "CViewEntityInvoice";
            Text = "CViewEntityAppUser";
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblUserMovies;
        private DataGridView dgvDetails;
    }
}