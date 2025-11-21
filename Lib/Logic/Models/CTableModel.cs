using Lib.Data;
using Lib.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Logic.Models
{
    public class CTableModel<T> : CBaseModel<T> where T : IEntity, new()
    {
        // ------------------------------------------------------------------
        public CTableModel(String p_sTableName) : base(p_sTableName)
        {
        }
        // ------------------------------------------------------------------
        public override void Load() => this.table.LoadTable(null);
        // ------------------------------------------------------------------
        public override int Save()
        {
            int nResult = -1;
            IDbTransaction iTransaction = this.table.DB.BeginTransaction();
            try
            {
                this.table.SaveTable(iTransaction);
                iTransaction.Commit();
                nResult = 0;
            }
            catch
            {
                iTransaction.Rollback();
                throw;
            }
            return nResult;
        }
        // ------------------------------------------------------------------
    }
}
