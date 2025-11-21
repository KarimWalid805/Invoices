using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Data.Records;
using Lib.Data.Records;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Invoices.Data.Tables
{
    public class TableITEM : CDBTable<INVOICE>
    {
        public TableITEM(string p_sTableName) : base(p_sTableName)
        {
        }
        // --------------------------------------------------------------------------------------
        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            var oRecords = this.DB.Select<INVOICE>("select * from INVOICE", p_iTransaction);
            this.records.Clear();
            if (oRecords != null)
                this.records = oRecords;
        }
        // --------------------------------------------------------------------------------------
        public override void SaveTable(IDbTransaction? p_iTransaction)
        {
            if (this.records != null)
            {
        
                this.DB.SaveChanges<INVOICE>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"
                                                    insert into ITEM
                        (ID,CODE,MEASUREMENT_UNIT_CID, ITEM_CATEGORY_CID)
                        values 
                        (@ID,@CODE,@MEASUREMENT_UNIT_CID, @ITEM_CATEGORY_CID)",

                            // Provide the update statement that will be used for updated records
                            @"
                             update ITEM set 
                            CODE = @CODE,
                            MEASUREMENT_UNIT_CID = @MEASUREMENT_UNIT_CID
                            ITEM_CATEGORY_CID = @ITEM_CATEGORY_CID
                            where 
                            ID = @ID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            "delete from ITEM where ID = @ID",

                            p_iTransaction
                        );

                this.LoadTable(p_iTransaction);
            }
        }
    }
}
