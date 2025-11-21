using Flix.Logic.Modules;
using Flix.Logic.Entities;
using Lib.Logic;
using Lib.UX.DataForms;
using Lib.UX.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flix.UX;
using Lib.UX;

namespace Flix.UX.Views
{
    public partial class CViewEntitySupplier : Form, IEntityViewForm
    {
        protected DMGenre module { get; set; }
        protected CEditableGridDecorator detailsGrid;

        // --------------------------------------------------------------------------------------
        public CViewEntitySupplier()
        {
            InitializeComponent();
        }
        // --------------------------------------------------------------------------------------
        public void SetParent(Form p_oForm)
        {
            CFormTemplateMaster oMasterForm = (CFormTemplateMaster)p_oForm;

            this.detailsGrid = new CEditableGridDecorator(this.dgvDetails, oMasterForm.FormContext);
            oMasterForm.DetailGrids.Add(this.detailsGrid);

            this.module = (DMGenre)oMasterForm.Module;
        }
        // --------------------------------------------------------------------------------------
        public void WriteMasterToUI()
        {
            CGenre oCurrentGenre = this.module.MasterEntity;
            
            this.txtCodeId.Text = oCurrentGenre.CodeId.ToString();
            this.txtName.Text = oCurrentGenre.Name;
        }
        // --------------------------------------------------------------------------------------
        public void ReadMasterFromUI()
        {
            CGenre oCurrentGenre = this.module.MasterEntity;
            oCurrentGenre.Name = this.txtName.Text;
            oCurrentGenre.Change = EntityChangeType.UPDATED;
        }
        // --------------------------------------------------------------------------------------
        public void WriteDetailListToUI()
        {
            // [PATTERNS] Proxy
            this.detailsGrid.Populate<CMovie>(this.module.Details);
        }
        // --------------------------------------------------------------------------------------
    }
}
