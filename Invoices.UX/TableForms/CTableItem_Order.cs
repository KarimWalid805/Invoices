using Invoices.Logic.Entities;
using Invoices.Logic.Models;
using Lib.UX;

namespace Invoices.UX.TableForms
{
    public partial class CTableItem_Order : CFormTemplateTable
    {

        // [v3]
        public CItem_OrderModel Model = new CItem_OrderModel();

        // --------------------------------------------------------------------------------------
        public CTableItem_Order()
        {
            InitializeComponent();
        }
        // --------------------------------------------------------------------------------------
        
        #region // Virtual Methods \\
        // --------------------------------------------------------------------------------------
        protected override bool LoadModule()
        {
            // [v3] 
            Model.Load();
            // [PATTERNS] Visitor: The model is accepting a visit after loading
            Model.AcceptVisitAfterLoad(this.modelVisitor);

            return true;
        }
        // --------------------------------------------------------------------------------------
        protected override void DisplayModelEntitiesOnGrid()
        {
            // [v2]
            editableGridRecords.Populate<CItem_Order>(Model);
        }
        // --------------------------------------------------------------------------------------
        protected override bool SaveModule()
        {
            // [v54]
            // [PATTERNS] Visitor: The model is accepting a visit before saving
            Model.AcceptVisitBeforeSave(this.tableVisitor);

            // Saving the logic objects
            Model.Save();

            return true;
        }
        // --------------------------------------------------------------------------------------
        protected override string LastErrorMessage()
        {
            return this.Model.LastError;
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
