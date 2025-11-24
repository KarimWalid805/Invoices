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



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUserMovies = new Label();
            dgvDetails = new DataGridView();
            cboITEM_ORDER = new ComboBox();
            lblItem_Order = new Label();
            cboType = new ComboBox();
            label1 = new Label();
            cboCustomer = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // lblUserMovies
            // 
            lblUserMovies.AutoSize = true;
            lblUserMovies.Location = new Point(118, 118);
            lblUserMovies.Name = "lblUserMovies";
            lblUserMovies.Size = new Size(70, 15);
            lblUserMovies.TabIndex = 22;
            lblUserMovies.Text = "Invoice Line";
            // 
            // dgvDetails
            // 
            dgvDetails.Location = new Point(118, 147);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.Size = new Size(570, 344);
            dgvDetails.TabIndex = 21;
            // 
            // cboITEM_ORDER
            // 
            cboITEM_ORDER.FormattingEnabled = true;
            cboITEM_ORDER.Location = new Point(118, 40);
            cboITEM_ORDER.Name = "cboITEM_ORDER";
            cboITEM_ORDER.Size = new Size(240, 23);
            cboITEM_ORDER.TabIndex = 16;
            // 
            // lblItem_Order
            // 
            lblItem_Order.AutoSize = true;
            lblItem_Order.Location = new Point(45, 43);
            lblItem_Order.Name = "lblItem_Order";
            lblItem_Order.Size = new Size(67, 15);
            lblItem_Order.TabIndex = 18;
            lblItem_Order.Text = "Item Order:";
            // 
            // cboType
            // 
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(118, 69);
            cboType.Name = "cboType";
            cboType.Size = new Size(121, 23);
            cboType.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 72);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 24;
            label1.Text = "Type:";
            // 
            // cboCustomer
            // 
            cboCustomer.FormattingEnabled = true;
            cboCustomer.Location = new Point(118, 12);
            cboCustomer.Name = "cboCustomer";
            cboCustomer.Size = new Size(240, 23);
            cboCustomer.TabIndex = 25;
            // 
            // CViewEntityInvoices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 513);
            Controls.Add(cboCustomer);
            Controls.Add(label1);
            Controls.Add(cboType);
            Controls.Add(lblItem_Order);
            Controls.Add(cboITEM_ORDER);
            Controls.Add(lblUserMovies);
            Controls.Add(dgvDetails);
            Name = "CViewEntityInvoices";
            Text = "CViewEntityAppUser";
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lblUserMovies;
        private DataGridView dgvDetails;
        private ComboBox cboITEM_ORDER;
        private Label lblItem_Order;
        private ComboBox cboType;
        private Label label1;
        private ComboBox cboCustomer;
    }
}