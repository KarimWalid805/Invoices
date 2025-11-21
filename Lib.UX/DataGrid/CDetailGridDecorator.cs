using Lib.UX.DataForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataGrid
{
    public class CDetailGridDecorator : CEditableGridDecorator
    {
        public CDetailGridDecorator(DataGridView p_oWrappedControl, CDataFormContext p_oFormContext): base(p_oWrappedControl, p_oFormContext)
        {
            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.EditMode = DataGridViewEditMode.EditOnEnter;


            // Make combo changes commit immediately so the underlying entity updates as soon as user picks a value
            // [C#] [ADVANCED] Anonymous delegate. We use the method parameters with the lambda => operator pointing to the method body. 
            grid.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (grid.IsCurrentCellDirty && grid.CurrentCell is DataGridViewComboBoxCell)
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            // Optional: Do something when the entity has actually changed
            grid.CellValueChanged += (s, e) =>
            {
                if (e.RowIndex >= 0 && grid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
                {
    
                }
            };
        }
        // ------------------------------------------------------------------------------------------
        private DataGridViewColumn? FindColumnByDataPropertyName(string p_sDataPropertyName)
        {
            DataGridViewColumn? oFoundColumn = null;
            foreach (DataGridViewColumn oColumn in this.grid.Columns)
            {
                Debug.WriteLine(oColumn.DataPropertyName);
                if (oColumn.DataPropertyName.ToLower() == p_sDataPropertyName.ToLower())
                {
                    oFoundColumn = oColumn;
                    break;
                }
            }
            return oFoundColumn;
        }
        // ------------------------------------------------------------------------------------------
        public DataGridViewComboBoxColumn CreateLookupColumn(string p_sColumnDataPropertyName, Dictionary<string, string> p_oSetup)
        {
            //PATTERNS: Lazy Initialization. In this case we will create the column when it is first needed
            //          and prevent for adding it each time we load/create a new master entity
            DataGridViewColumn? oColumn = FindColumnByDataPropertyName(p_sColumnDataPropertyName);
            if (oColumn != null)
                oColumn.Visible = false;

            DataGridViewComboBoxColumn oNewColumn = new DataGridViewComboBoxColumn
            {
                FlatStyle = FlatStyle.Popup,
                HeaderText = p_oSetup["Text"],
                Width = 200,
                ValueMember = p_oSetup["ValueMember"],      // The key field of the lookup entity
                DisplayMember = p_oSetup["DisplayMember"],  // The field that will used for displaying a lookup entity
                DataPropertyName = p_oSetup["ForeignKey"],  // The foreign key field on the detail entity that will receive the selected value

                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
            };

            this.grid.Columns.Add(oNewColumn);

            return oNewColumn;
        }
        // ------------------------------------------------------------------------------------------
        protected override void DoOnDataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            Debug.WriteLine(e.ToString());
            e.ThrowException = false;
        }
        // ------------------------------------------------------------------------------------------
    }
}
