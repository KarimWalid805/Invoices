using Invoices.Data.Records;
using Lib.Data.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Invoices.Data.Tables
{
    public class TableITEM_ORDER : CDBTable<ITEM_ORDER>
    {
        public TableITEM_ORDER() : base("ItemOrder")
        {
        }
        // --------------------------------------------------------------------------------------
        public override void LoadTable(IDbTransaction p_iTransaction)
        {
            var oRecords = this.DB.Select<ITEM_ORDER>("select * from ITEM_ORDER");

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
            {
                this.records = oRecords;

                foreach (var oRecord in this.records)
                    Debug.WriteLine(oRecord.ToString());
            }
        }
        // --------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------
        public override void SaveTable(IDbTransaction? p_iTransaction)
        {
            if (this.records != null)
            {
                this.DB.SaveChanges<ITEM_ORDER>(this.records,

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
