using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Logic;

using Lib.UX.DataForms;

namespace Lib.UX.DataGrid
{
    // [PATTERNS] Decorator. An object of this class "wraps" a DataGridView control 
    // adding extra functionality at runtime.
    // This extra functionality allows the user to edit entities on the bound list of entities
    public class CEditableGridDecorator
    {
        // ....................................................................
        protected DataGridView grid;
        
        public DataGridView Grid { get { return grid; } }
        // ....................................................................
        private IBindingList? _bindingList = null;
        // ....................................................................
        public IEntity? GridCurrentEntity
        {
            get
            {
                IEntity? oResult = null;
                if (this.grid.CurrentRow != null)
                { 
                    try
                    { 
                        oResult = this.grid.CurrentRow.DataBoundItem as IEntity;
                    }
                    catch(Exception E)
                    {
                         Debug.WriteLine(E.Message);
                    }
                }

                return oResult;
            }
        }
        // ....................................................................
        // [PATTERNS] State: This is the context of the table form state machine on which actions will be performed
        private CDataFormContext? formContext = null;
        // ....................................................................
        public PropertyChangedEventHandler? EntityChangeHandler { get; set; } = null;
        // ....................................................................
        private bool isPopulating = false;

        // --------------------------------------------------------------------------------------
        public CEditableGridDecorator(DataGridView p_oWrappedControl)
        {
            grid = p_oWrappedControl;
            grid.RowsAdded += DoOnAddRow;
            grid.CellEndEdit += DoOnEditRow;
            grid.KeyDown += DoOnGridKeyDown;
        }
        // --------------------------------------------------------------------------------------
        public CEditableGridDecorator(DataGridView p_oWrappedControl, CDataFormContext p_oFormContext)
        {
            formContext = p_oFormContext;

            grid = p_oWrappedControl;
            grid.CellEndEdit += DoOnEditRow;
            grid.RowsAdded += DoOnAddRow;
            grid.KeyDown += DoOnGridKeyDown;
            grid.DataError += DoOnDataError;
        }
        // --------------------------------------------------------------------------------------
        public void NewRow<T>(T p_oEntity)
        {
            _bindingList?.Add(p_oEntity);
            int nCurrentColumn = this.grid.CurrentCell.ColumnIndex;
            if (this.grid.Rows.Count > 2)
                this.grid.CurrentCell = this.grid.Rows[this.grid.Rows.Count - 2].Cells[nCurrentColumn];
            this.AddRow();
        }
        // --------------------------------------------------------------------------------------
        private void DoOnAddRow(object? sender, DataGridViewRowsAddedEventArgs e)
        {
            AddRow();
        }
        // --------------------------------------------------------------------------------------
        private void DoOnEditRow(object? sender, DataGridViewCellEventArgs e)
        {
            if (this.GridCurrentEntity != null)
            {
                Debug.WriteLine("Column Edit");
                this.GridCurrentEntity.Change = EntityChangeType.UPDATED;
                this.grid.Refresh();

                // [PATTERNS] State: Trigger an action that could lead to a state change
                if (formContext != null)
                    formContext.PerformAction("EditRow");
            }
        }
        // --------------------------------------------------------------------------------------
        private void DoOnGridKeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        if (DeleteRow())
                            e.Handled = true;
                        break;
                    }
            }
        }
        // --------------------------------------------------------------------------------------
        protected virtual void DoOnDataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception?.Message);
        }
        // --------------------------------------------------------------------------------------
        public void Populate<T>(List<T> p_oEntityList)
        {
            isPopulating = true;
            try
            { 
                // Create a BindingsList to allow table edit operations
                _bindingList = new BindingList<T>(p_oEntityList);
                this.grid.AutoGenerateColumns = true;
                this.grid.DataSource = null;
                this.grid.DataSource = _bindingList;
                this.grid.SetColumnSizes(typeof(T));
                this.grid.Select();
                Debug.WriteLine($"Auto-created grid columns:{this.grid.Columns.Count}");
            }
            finally
            { 
                isPopulating = false; 
            }
        }
        // --------------------------------------------------------------------------------------
        public bool AddRow()
        {
            bool bResult = false;
            if ((!isPopulating) & (this.GridCurrentEntity != null))
            {
                Debug.WriteLine("Add Row");
                this.GridCurrentEntity.Change = EntityChangeType.CREATED;
                if (EntityChangeHandler != null)
                    this.GridCurrentEntity.OnPropertyChange += EntityChangeHandler;
                
                // [PATTERNS] State: Trigger an action that could lead to a state change
                if (formContext != null)
                    formContext.PerformAction("CreateRow");
                bResult = true;
            }
            return bResult;
        }
        // --------------------------------------------------------------------------------------
        public bool DeleteRow()
        {
            bool bResult = false;
            if (!this.grid.ReadOnly)
            {
                if (this.GridCurrentEntity != null)
                {
                    DialogResult oResult = MessageBox.Show("Delete this record?", "Warning", MessageBoxButtons.YesNo
                                                , MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (oResult == DialogResult.Yes)
                    {
                        this.GridCurrentEntity.Change = EntityChangeType.DELETED;
                        Debug.WriteLine("Delete Row");
                        this.grid.Rows.RemoveAt(this.grid.CurrentRow.Index);
                        this.grid.Refresh();
                        
                        // [PATTERNS] State: Trigger an action that could lead to a state change
                        if (formContext != null)
                            formContext.PerformAction("DeleteRow");
                        bResult = true;
                    }
                }
            }
            return bResult;
        }
        // --------------------------------------------------------------------------------------

    }
}
