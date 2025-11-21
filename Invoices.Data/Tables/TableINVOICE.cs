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
    public class TableINVOICE: CDBTable<INVOICE>
    {
        public TableINVOICE(string p_sTableName) : base(p_sTableName)
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
                                                    insert into INVOICE
                        (ID,IS_CUSTOMER_INVOICE,CUSTOMER_ID,SUPPLIER_ID, ITEM_ORDER_ID)
                        values 
                        (@ID,@IS_CUSTOMER_INVOICE,@CUSTOMER_ID,@SUPPLIER_ID, @ITEM_ORDER_ID)",

                            // Provide the update statement that will be used for updated records
                            @"
                             update INVOICE set 
                            IS_CUSTOMER_INVOICE = @IS_CUSTOMER_INVOICE,
                            CUSTOMER_ID = @CUSTOMER_ID
                            SUPPLIER_ID = @SUPPLIER_ID,
                            ITEM_ORDER_ID = @ITEM_ORDER_ID
                            where 
                            ID = @ID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            "delete from INVOICE where ID = @ID",

                            p_iTransaction
                        );

                this.LoadTable(p_iTransaction);
            }
        }
    }
}
