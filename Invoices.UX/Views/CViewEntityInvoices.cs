using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoices.Logic.Builders;
using Invoices.Logic.Entities;
using Invoices.Logic.Models;
using Invoices.Logic.Modules;
using Invoices.Logic.Entities;
using Invoices.Logic.Modules;
using Lib.Logic;
using Lib.UX;
using Lib.UX.DataForms;
using Lib.UX.DataGrid;

namespace Invoices.UX.Views
{
    public partial class CViewEntityInvoices : Form, IEntityViewForm
    {
        protected DMInvoices module { get; set; } = null!;
        protected CInvoice_LineModel detailModel { get; set; } = null!;
        protected CDetailGridDecorator detailsGrid;

        // --------------------------------------------------------------------------------------
        public CViewEntityInvoices()
        {
            InitializeComponent();
        }
        // --------------------------------------------------------------------------------------
        public void SetParent(Form p_oForm)
        {
            CFormTemplateMaster oMasterForm = (CFormTemplateMaster)p_oForm;

            this.detailsGrid = new CDetailGridDecorator(this.dgvDetails, oMasterForm.FormContext);
            oMasterForm.DetailGrids.Add(this.detailsGrid);

            this.module = (DMInvoices)oMasterForm.Module;
        }

        // --------------------------------------------------------------------------------------
        public void WriteMasterToUI()
        {
            CInvoice oCurrentInvoice = this.module.MasterEntity;
            if (oCurrentInvoice == null)
                return;

            PopulateInvoiceType();
            if (oCurrentInvoice.IS_CUSTOMER_INVOICE >= 0 && oCurrentInvoice.IS_CUSTOMER_INVOICE < this.cboType.Items.Count)
                this.cboType.SelectedIndex = oCurrentInvoice.IS_CUSTOMER_INVOICE;
            else
                this.cboType.SelectedIndex = -1;

            DisplayCustomerLookup(oCurrentInvoice);
            DisplayItemOrderLookup(oCurrentInvoice);
        }

        private void PopulateInvoiceType()
        {
            this.cboType.Items.Clear();
            this.cboType.Items.Add("Customer Invoice"); // index 0
            this.cboType.Items.Add("Supplier Invoice"); // index 1
        }
        // --------------------------------------------------------------------------------------
        public void ReadMasterFromUI()
        {
            CInvoice oCurrentInvoice = this.module.MasterEntity;
            if (oCurrentInvoice != null)
            {
                oCurrentInvoice.IS_CUSTOMER_INVOICE = this.cboType.SelectedIndex;

                if (this.cboITEM_ORDER.SelectedItem != null)
                {
                    CItem_Order selectedOrder = (CItem_Order)this.cboITEM_ORDER.SelectedItem;
                    oCurrentInvoice.ITEM_ORDER_ID = selectedOrder.ID;
                }

                if (this.cboCustomer.SelectedItem != null)
                {
                    CCustomer selectedCustomer = (CCustomer)this.cboCustomer.SelectedItem;
                    oCurrentInvoice.CUSTOMER_ID = selectedCustomer.ID;
             
                }
                
            }
        }
        // --------------------------------------------------------------------------------------
        public void WriteDetailListToUI()
        {
            // [PATTERNS] Proxy
            this.detailsGrid.Populate<CInvoice_Line>(this.module.Details);

            addItemLookupColumn(this.module.Lookups[CDataModuleBuilderInvoice.LOOKUP_ITEM]);
           
        }
        // --------------------------------------------------------------------------------------



        #region (( Custom Code for Lookups ))
        // --------------------------------------------------------------------------------------
        // Prepare a combo box that is designed on the form to functiona as lookup for the master (AppUser)
        // and load all lookup entities (CSubscriptionPlans)
        private void DisplayItemOrderLookup(CInvoice p_oCurrentInvoice)
        {
            this.cboITEM_ORDER.ValueMember = "ID";
            this.cboITEM_ORDER.DisplayMember = "STORE_CID";
            this.cboITEM_ORDER.Items.Clear();

            CItem_OrderModel lookup = (CItem_OrderModel)this.module.Lookups[CDataModuleBuilderInvoice.LOOKUP_ITEM_ORDER];
            foreach (CItem_Order order in lookup)
                this.cboITEM_ORDER.Items.Add(order);

            p_oCurrentInvoice.LookupItemOrder(lookup);
            this.cboITEM_ORDER.SelectedItem = p_oCurrentInvoice.ITEM_ORDER;
        }

        private void DisplayCustomerLookup(CInvoice p_oCurrentInvoice)
        {
            this.cboCustomer.ValueMember = "ID";
            this.cboCustomer.DisplayMember = "CUST_NAME";
            this.cboCustomer.Items.Clear();

            CCustomerModel lookup = (CCustomerModel)this.module.Lookups[CDataModuleBuilderInvoice.LOOKUP_CUSTOMER];
            foreach (CCustomer cust in lookup)
                this.cboCustomer.Items.Add(cust);

            p_oCurrentInvoice.LookupCustomer(lookup);
            this.cboCustomer.SelectedItem = p_oCurrentInvoice.CUSTOMER;
            this.cboCustomer.Text = p_oCurrentInvoice.CUSTOMER?.CUST_NAME ?? "Select customer";
        }

        // --------------------------------------------------------------------------------------
        // Create a lookup combo box column on the grid for the detail (AppUserMovies)
        // and load all lookup entities (Movies)
        private void addItemLookupColumn(IModel p_oLookupModel)
        {
            Dictionary<string, string> oLookupSetup = new Dictionary<string, string>()
            {
                ["Text"] = "Item",        // The title of the column
                ["ValueMember"] = "Id",         // The key field of the lookup entity
                ["DisplayMember"] = "CODE",     // The field that will used for displaying a lookup entity
                ["ForeignKey"] = "ITEM_ID"      // The foreign key field on the detail entity that will receive the selected value
            };
            DataGridViewComboBoxColumn oItemLookup = this.detailsGrid.CreateLookupColumn("Item", oLookupSetup);

            oItemLookup.DataSource = null;
            oItemLookup.DataSource = ((CItemModel)p_oLookupModel).ToList();

        }
     
        // --------------------------------------------------------------------------------------
        #endregion


    }
}
