using Lib.Logic.Visitors;
using Lib.UX.DataForms.TableForm;
using Lib.UX.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lib.UX
{
    public partial class CFormTemplateTable : Form
    {
        //[v4]
        // [PATTERNS] State: A context for the current state of the form
        protected CTableFormContext formContext;
        protected CEditableGridDecorator editableGridRecords;
        protected CVisitorToModel modelVisitor = new CVisitorToModel();
        protected CVisitorToTable tableVisitor = new CVisitorToTable();


        // --------------------------------------------------------------------------------------
        public CFormTemplateTable()
        {
            InitializeComponent();
            // [PATTERNS] State: Creates a new context and assigns the controls that will be handled by the states of the context.
            // Then initializes the context with the initial state.
            this.formContext = new CTableFormContext(this.btnLoadTable, this.btnSaveTable, this.btnCancel);
            this.formContext.Initialize(typeof(CTableFormStateInitial));

            this.editableGridRecords = new CEditableGridDecorator(this.gridRecords, formContext);
        }
        // --------------------------------------------------------------------------------------
        // [PATTERNS] Template Method: The skeleton of the table editing form functionality is defined here,
        // it allows a descendand to override some parts with its custom functionality, but the descendand cannot
        // override the whole template method.
        private void doLoad()
        {
            this.gridRecords.DataSource = null;
            if (LoadModule())
            { 
                this.DisplayModelEntitiesOnGrid();
                // [PATTERNS] State: Inform the state machine that the table has been loaded by performing the action "TableLoaded"
                this.formContext.PerformAction("TableLoaded");
            }
            else
                MessageBox.Show(LastErrorMessage(), " Error");
        }
        // --------------------------------------------------------------------------------------
        // [PATTERNS] Template Method: The skeleton of the table editing form functionality is defined here,
        // it allows a descendand to override some parts with its custom functionality, but the descendand cannot
        // override the whole template method.
        private void doSave()
        {
            DialogResult oResult = MessageBox.Show("Save changes?", "Warning"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (oResult == DialogResult.Yes)
            {
                if (SaveModule())
                {
                    this.gridRecords.DataSource = null;
                    if (LoadModule())
                    { 
                        this.DisplayModelEntitiesOnGrid();
                        // [PATTERNS] State: Inform the state machine that the table has been loaded by performing the action "TableLoaded"
                        this.formContext.PerformAction("TableLoaded");
                    }
                    else
                        MessageBox.Show(LastErrorMessage(), "Error");
                }
                else
                    MessageBox.Show(LastErrorMessage(), "Error");
            }
        }
        // --------------------------------------------------------------------------------------
        private void doCancel()
        {
            DialogResult oResult = MessageBox.Show("Cancel changes?", "Warning"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (oResult == DialogResult.Yes)
                doLoad();
        }
        // --------------------------------------------------------------------------------------
        private void DoOnAnyCommand(object sender, EventArgs e)
        {
            if (sender == this.btnLoadTable)
                doLoad();
            else if (sender == this.btnSaveTable)
                doSave();
            else
                doCancel();
        }
        // --------------------------------------------------------------------------------------


        #region // Virtual Methods \\
        // [PATTERNS] Template Method: These are the virtual methods called by the template methods
        // which can be overriden with custom functionality by the descendant.
        // --------------------------------------------------------------------------------------
        protected virtual bool LoadModule()
        {
            return false;
        }
        // --------------------------------------------------------------------------------------
        protected virtual void DisplayModelEntitiesOnGrid()
        {
        }
        // --------------------------------------------------------------------------------------
        protected virtual bool SaveModule()
        {
            return false;
        }
        // --------------------------------------------------------------------------------------
        protected virtual string LastErrorMessage()
        {
            return String.Empty;
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
