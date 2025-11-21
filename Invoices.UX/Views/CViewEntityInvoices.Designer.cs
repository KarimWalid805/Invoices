namespace Invoices.UX.Views
{
    partial class CViewEntityInvoices
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
            lblSubscriptionPlan = new Label();
            cboSubscriptionPlan = new ComboBox();
            lblSubscriptionStartDate = new Label();
            dtSubscriptionStartDate = new DateTimePicker();
            lblSubscriptionEndDate = new Label();
            dtSubscriptionEndDate = new DateTimePicker();
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
            // lblSubscriptionPlan
            // 
            lblSubscriptionPlan.AutoSize = true;
            lblSubscriptionPlan.Location = new Point(10, 43);
            lblSubscriptionPlan.Name = "lblSubscriptionPlan";
            lblSubscriptionPlan.Size = new Size(102, 15);
            lblSubscriptionPlan.TabIndex = 18;
            lblSubscriptionPlan.Text = "Subscription Plan:";
            // 
            // cboSubscriptionPlan
            // 
            cboSubscriptionPlan.FormattingEnabled = true;
            cboSubscriptionPlan.Location = new Point(118, 40);
            cboSubscriptionPlan.Name = "cboSubscriptionPlan";
            cboSubscriptionPlan.Size = new Size(240, 23);
            cboSubscriptionPlan.TabIndex = 16;
            // 
            // lblSubscriptionStartDate
            // 
            lblSubscriptionStartDate.AutoSize = true;
            lblSubscriptionStartDate.Location = new Point(5, 75);
            lblSubscriptionStartDate.Name = "lblSubscriptionStartDate";
            lblSubscriptionStartDate.Size = new Size(107, 15);
            lblSubscriptionStartDate.TabIndex = 19;
            lblSubscriptionStartDate.Text = "Subscription From:";
            // 
            // dtSubscriptionStartDate
            // 
            dtSubscriptionStartDate.Format = DateTimePickerFormat.Short;
            dtSubscriptionStartDate.Location = new Point(118, 69);
            dtSubscriptionStartDate.Name = "dtSubscriptionStartDate";
            dtSubscriptionStartDate.ShowCheckBox = true;
            dtSubscriptionStartDate.Size = new Size(215, 23);
            dtSubscriptionStartDate.TabIndex = 14;
            // 
            // lblSubscriptionEndDate
            // 
            lblSubscriptionEndDate.AutoSize = true;
            lblSubscriptionEndDate.Location = new Point(354, 75);
            lblSubscriptionEndDate.Name = "lblSubscriptionEndDate";
            lblSubscriptionEndDate.Size = new Size(19, 15);
            lblSubscriptionEndDate.TabIndex = 20;
            lblSubscriptionEndDate.Text = "To";
            // 
            // dtSubscriptionEndDate
            // 
            dtSubscriptionEndDate.Format = DateTimePickerFormat.Short;
            dtSubscriptionEndDate.Location = new Point(379, 69);
            dtSubscriptionEndDate.Name = "dtSubscriptionEndDate";
            dtSubscriptionEndDate.ShowCheckBox = true;
            dtSubscriptionEndDate.Size = new Size(200, 23);
            dtSubscriptionEndDate.TabIndex = 15;
            // 
            // lblUserMovies
            // 
            lblUserMovies.AutoSize = true;
            lblUserMovies.Location = new Point(118, 118);
            lblUserMovies.Name = "lblUserMovies";
            lblUserMovies.Size = new Size(140, 15);
            lblUserMovies.TabIndex = 22;
            lblUserMovies.Text = "Movies Watched By User:";
            // 
            // dgvDetails
            // 
            dgvDetails.Location = new Point(118, 147);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.Size = new Size(570, 344);
            dgvDetails.TabIndex = 21;
            // 
            // CViewEntityAppUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 513);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblSubscriptionPlan);
            Controls.Add(cboSubscriptionPlan);
            Controls.Add(lblSubscriptionStartDate);
            Controls.Add(dtSubscriptionStartDate);
            Controls.Add(lblSubscriptionEndDate);
            Controls.Add(dtSubscriptionEndDate);
            Controls.Add(lblUserMovies);
            Controls.Add(dgvDetails);
            Name = "CViewEntityAppUser";
            Text = "CViewEntityAppUser";
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblSubscriptionPlan;
        private ComboBox cboSubscriptionPlan;
        private Label lblSubscriptionStartDate;
        private DateTimePicker dtSubscriptionStartDate;
        private Label lblSubscriptionEndDate;
        private DateTimePicker dtSubscriptionEndDate;
        private Label lblUserMovies;
        private DataGridView dgvDetails;
    }
}