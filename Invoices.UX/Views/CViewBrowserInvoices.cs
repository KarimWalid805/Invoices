using Lib.Logic;
using Lib.UX.DataForms;
using Invoices.Logic.Models;
using Lib.UX.Controls;
using Lib.UX;

namespace Invoices.UX.Views
{
    public partial class CViewBrowserInvoices : Form, IBrowserViewForm
    {
        protected CInvoiceBrowserModel browserModel = null!;
        protected CFormTemplateMaster parent = null!;

        // ....................................................................
        public bool HasSelectedInBrowser
        {
            get
            {
                bool bResult = false;
                if (lstBrowser.SelectedItem != null)
                {
                    IEntity? oCurrentEntity = lstBrowser.SelectedItem as IEntity;
                    if (oCurrentEntity != null)
                        bResult = oCurrentEntity.PrimaryKeyValue > 0;
                }
                return bResult;
            }
        }
        // ....................................................................
        public IEntity? SelectedEntity { get { return lstBrowser.SelectedItem as IEntity;} }
        // ....................................................................



        // --------------------------------------------------------------------------------------
        public CViewBrowserInvoices(CInvoiceBrowserModel p_oBrowserModel)
        {
            InitializeComponent();
            this.browserModel = p_oBrowserModel;
        }
        // --------------------------------------------------------------------------------------
        public void SetParent(Form p_oForm)
        {
            this.parent = (CFormTemplateMaster)p_oForm;
            // Sets the title on the master-detail form
            this.parent.Text = "Invoices";
        }
        // --------------------------------------------------------------------------------------
        public void Display(Control p_oContainer)
        {
            // [PATTERNS] Visitor. The control is a visitor here, and display method accepts the visit to this object.
            p_oContainer.DisplayView(this);
        }
        // --------------------------------------------------------------------------------------
        public void WriteBrowserListToUI()
        {
            this.lstBrowser.DataSource = null;
            this.lstBrowser.DataSource = this.browserModel;
        }
        // --------------------------------------------------------------------------------------
        private void FindByName()
        {
            string sSearchStr = this.txtSearch.Text;

            // Fix for CS7036: Ensure that the string is converted to lowercase using the correct method.
            var oFound = this.browserModel
                .Where(x => x.CustomerName.ToString().ToLowerInvariant().Contains(sSearchStr.ToLowerInvariant()))
                .ToList();

            if (oFound.Count > 0)
                this.lstBrowser.SelectedItem = oFound[0];
        }
        // --------------------------------------------------------------------------------------
        private void DoOnAnyCommand(object sender, EventArgs e)
        {
            if (sender == btnFind)
                FindByName();
            else if (sender == lstBrowser)
                // Trigger an open event on the parent form context, to switch to the entity view
                this.parent.FormContext.HandleEvent(this.parent.FormContext.Open);
        }
        // --------------------------------------------------------------------------------------
        private void DoOnAnyKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (sender == txtSearch)
                {
                    FindByName();
                    this.lstBrowser.Focus();
                    this.lstBrowser.Select();
                    e.Handled = true;
                }
                else if (sender == lstBrowser)
                {
                    // Trigger an open event on the parent form context, to switch to the entity view
                    this.parent.FormContext.HandleEvent(this.parent.FormContext.Open);
                    e.Handled = true;
                }
            }
        }
        // --------------------------------------------------------------------------------------
    }
}
