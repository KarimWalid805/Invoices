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
            if (oCurrentInvoice != null)
            { 
            
            }
        }
        // --------------------------------------------------------------------------------------
        public void ReadMasterFromUI()
        {
            CInvoice oCurrentInvoice = this.module.MasterEntity;
            if (oCurrentInvoice != null)
            {
              
            }
        }
        // --------------------------------------------------------------------------------------
        public void WriteDetailListToUI()
        {
            // [PATTERNS] Proxy
            this.detailsGrid.Populate<CInvoice_Line>(this.module.Details);

            addMovieLookupColumn(this.module.Lookups[CDataModuleBuilderInvoice.LOOKUP_MOVIES]);
        }
        // --------------------------------------------------------------------------------------



        #region (( Custom Code for Lookups ))
        // --------------------------------------------------------------------------------------
        // Prepare a combo box that is designed on the form to functiona as lookup for the master (AppUser)
        // and load all lookup entities (CSubscriptionPlans)
        private void displaySubscriptionPlanLookup(CInvoice p_oCurrentInvoice)
        {
            //// Loads all the options
            //this.cboSubscriptionPlan.ValueMember = "CodeID";
            //this.cboSubscriptionPlan.DisplayMember = "Description";
            //this.cboSubscriptionPlan.Items.Clear();
            //CSubscriptionPlanModel oLookup = (CSubscriptionPlanModel)this.module.Lookups[CDataModuleBuilderAppUser.LOOKUP_SUBSCRIPTION_PLAN];

            //foreach (CSubscriptionPlan oPlan in oLookup)
            //    this.cboSubscriptionPlan.Items.Add(oPlan);

            //// Run the lookup relation to get the foreign entity and its fiedls;
            //p_oCurrentInvoice.LookupCustomer(oLookup);

            //this.cboSubscriptionPlan.SelectedItem = p_oCurrentAppUser.SubscriptionPlan;
            //// [C#] The single ? is for a nullable type. On the right side of the null coalescence operator ?? is what to show in case of null
            //this.cboSubscriptionPlan.Text = p_oCurrentAppUser.SubscriptionPlan?.Description ?? "No plan";
        }
        // --------------------------------------------------------------------------------------
        // Create a lookup combo box column on the grid for the detail (AppUserMovies)
        // and load all lookup entities (Movies)
        private void addMovieLookupColumn(IModel p_oLookupModel)
        {
            Dictionary<string, string> oLookupSetup = new Dictionary<string, string>()
            {
                ["Text"] = "Movie Name",        // The title of the column
                ["ValueMember"] = "Id",         // The key field of the lookup entity
                ["DisplayMember"] = "Name",     // The field that will used for displaying a lookup entity
                ["ForeignKey"] = "MovieId"      // The foreign key field on the detail entity that will receive the selected value
            };
            DataGridViewComboBoxColumn oMovieLookupColumn = this.detailsGrid.CreateLookupColumn("MovieName", oLookupSetup);

            oMovieLookupColumn.DataSource = null;
            oMovieLookupColumn.DataSource = p_oLookupModel;
        }
        // --------------------------------------------------------------------------------------
        #endregion


    }
}
