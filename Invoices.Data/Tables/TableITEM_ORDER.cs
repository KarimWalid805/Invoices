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
    public class TableITEM_ORDER : CDBTable<INVOICE>
    {
        public TableITEM_ORDER(string p_sTableName) : base(p_sTableName)
        {
        }
        // --------------------------------------------------------------------------------------
        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            var oRecords = this.DB.Select<INVOICE>("select * from ITEM_ORDER", p_iTransaction);
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
                                                    insert into ITEM_ORDER
                        (ID,IS_CUSTOMER_ORDER,CUSTOMER_ID, SUPPLIER_ID)
                        values 
                        (@ID,@IS_CUSTOMER_ORDER,@CUSTOMER_ID, @SUPPLIER_ID)",

                            // Provide the update statement that will be used for updated records
                            @"
                             update ITEM_ORDER set 
                            IS_CUSTOMER_ORDER = @IS_CUSTOMER_ORDER,
                            CUSTOMER_ID = @CUSTOMER_ID,
                            SUPPLIER_ID = @SUPPLIER_ID,
                            ORDER_DATETIME = @ORDER_DATETIME,
                            STORE_CID = @STORE_CID
                            where 
                            ID = @ID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            "delete from ITEM_ORDER where ID = @ID",

                            p_iTransaction
                        );

                this.LoadTable(p_iTransaction);
            }
        }
    }
}
