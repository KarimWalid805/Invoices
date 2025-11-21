

using Flix.Logic.Entities;
using Flix.Logic.Models;
using Lib.UX;

namespace Flix.UX.TableForms
{
    public partial class CTableFormSubscriptionPlan : CFormTemplateTable
    {

        // [v3]
        public CSubscriptionPlanModel Model = new CSubscriptionPlanModel();

        // --------------------------------------------------------------------------------------
        public CTableFormSubscriptionPlan()
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
            editableGridRecords.Populate<CSubscriptionPlan>(Model);
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
