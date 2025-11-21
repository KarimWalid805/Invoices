using System.Data;
using Lib.Data;
using Lib.Logic;
using Lib.Logic.Visitors;


namespace Lib.Logic.Models
{
    public class CBaseModel<T>: List<T>, IModel where T: IEntity, new()
    {
        // ...........................................................
        private string _tableName = "";
        public String TableName { get { return _tableName; } }
        // ...........................................................
        protected IDBTable table;
        public IDBTable Table 
        {   get { return table; } 
            set { table = value; 
                  if (table == null)                      
                    throw new Exception($"Class for table identifier {_tableName} is not registered with the data tier factory");	
                } 
        }
        // ...........................................................
        protected string lastError = String.Empty;
        public string LastError { get { return lastError; } }
        // ...........................................................

        // ------------------------------------------------------------------
        public CBaseModel(String p_sTableName)
        {
            _tableName = p_sTableName;
        }
        // ------------------------------------------------------------------
        public void Empty()
        {
            this.Clear();
            this.table.RecordSet.Clear();
        }
        // ------------------------------------------------------------------

        #region // IModel \\
        // ------------------------------------------------------------------
        public virtual void AcceptVisitAfterLoad(CVisitorToModel p_oVisitor)
        {
            p_oVisitor.VisitCopy(this.table, this);
        }
        // ------------------------------------------------------------------
        public virtual void AcceptVisitBeforeSave(CVisitorToTable p_oVisitor)
        {
            p_oVisitor.VisitAddNew(this, this.table);
        }
        // ------------------------------------------------------------------
        public virtual IEntity New()
        {
            throw new NotImplementedException();
        }
        // ------------------------------------------------------------------
        public virtual void Load()
        {
            throw new NotImplementedException();
        }
        // ------------------------------------------------------------------
        public virtual void Delete()
        {
            throw new NotImplementedException();
        }
        // ------------------------------------------------------------------
        public virtual int Save()
        {
            throw new NotImplementedException();
        }
        // ------------------------------------------------------------------
        #endregion
    }
}
