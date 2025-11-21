using Invoices.UX.Builders;
using Invoices.UX;
using Invoices.UX.TableForms;
using Lib.UX.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace WindowsApp
{
    public partial class CFormMain : Form
    {
        //public CFormTableSubscriptionPlan? FormTableSubscriptionPlan = null;

        // --------------------------------------------------------------------------------------
        public CFormMain()
        {
            InitializeComponent();
        }
        // --------------------------------------------------------------------------------------
        private void DoOnAnyCommand(object sender, EventArgs e)
        {
            if (sender == mnuAppUsers)
                // [PATTERNS] Builder: We create a director for the construction of a master form, 
                // and we perform the construction with the given builder object
                new CMasterFormDirector(this).ConstructUX(new CMasterFormBuilderInvoice()).Show();
            
            
           
        }
        // --------------------------------------------------------------------------------------
    }
}
