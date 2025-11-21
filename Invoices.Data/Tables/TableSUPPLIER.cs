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
    public class TableSUPPLIER : CDBTable<INVOICE>
    {
        public TableSUPPLIER(string p_sTableName) : base(p_sTableName)
        {
        }
        // --------------------------------------------------------------------------------------
        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            var oRecords = this.DB.Select<INVOICE>("select * from SUPPLIER", p_iTransaction);
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
                                                    insert into SUPPLIER
                        (ID,SUPPLIER_CATEGORY_CID)
                        values 
                        (@ID,@SUPPLIER_CATEGORY_CID)",

                            // Provide the update statement that will be used for updated records
                            @"
                             update SUPPLIER set 
                            SUPPLIER_CATEGORY_CID = @SUPPLIER_CATEGORY_CID
                            where 
                            ID = @ID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            "delete from SUPPLIER where ID = @ID",

                            p_iTransaction
                        );

                this.LoadTable(p_iTransaction);
            }
        }
    }
}
