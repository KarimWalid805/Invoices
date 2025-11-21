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
    public class CMasterModel<M, D> : CBaseModel<M> where M : IEntity, new() where D: IEntity, new()
    {
        // ....................................................................
        public M MasterEntity 
        {   get 
            {   if (this.Count == 0) 
                    return default(M)!; 
                else 
                    return this[0]; 
            } 
        }
        // ....................................................................
        public CBaseModel<D> DetailsModel { get; set; } = null!;
        // ....................................................................
        public int MasterKey { get; set; } = -1;
        // ....................................................................


        // ------------------------------------------------------------------
        public CMasterModel(String p_sTableName) : base(p_sTableName)
        {
        }
        // ------------------------------------------------------------------
        public override IEntity New()
        {
            this.Empty();
            this.DetailsModel.Empty();

            M oNewMasterEntity = new M();
            oNewMasterEntity.Change = EntityChangeType.CREATED;
            this.Add(oNewMasterEntity);

            return oNewMasterEntity;
        }
        // ------------------------------------------------------------------
        public override void Load()
        {
            this.Table.LoadRecord(this.MasterKey);
            this.DetailsModel.Table.LoadTable(null, this.MasterKey);
        }
        // ------------------------------------------------------------------
        public override void Delete()
        {
            this.MasterEntity.Change = EntityChangeType.DELETED;
            foreach (var oDetail in this.DetailsModel)
                oDetail.Change = EntityChangeType.DELETED;
            Save();
        }
        // ------------------------------------------------------------------
        public override int Save()
        {
            using (IDbTransaction iTransaction = this.Table.DB.BeginTransaction())
            {
                try
                {
                    // When not deleting, you should insert/update the master before the details
                    if (this.MasterEntity.Change != EntityChangeType.DELETED)
                        this.Table.SaveTable(iTransaction);

                    
                    this.MasterKey = this.MasterEntity.PrimaryKeyValue;
                    foreach (IEntity oDetail in this.DetailsModel)
                        oDetail.ForeignKeyOfMasterValue = this.MasterKey;

                    this.DetailsModel.Table.SaveTable(iTransaction);        // Insert/update the details.

                    // When deleting the master, you should do that after you've deleted the details
                    if (this.MasterEntity.Change == EntityChangeType.DELETED)
                        this.Table.SaveTable(iTransaction);          // First insert/update the master.

                    iTransaction.Commit();
                }
                catch
                {
                    iTransaction.Rollback();
                    throw;
                }
            }
            return this.MasterKey;
        }
        // ------------------------------------------------------------------
    }
}
