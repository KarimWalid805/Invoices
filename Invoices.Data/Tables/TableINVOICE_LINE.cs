
using Invoices.Data.Records;
using Lib.Data.Records;
using System.Data;
using System.Diagnostics;


namespace Invoices.Data.Tables
{
    public class TableINVOICE_LINE : CDBTable<INVOICE>
    {
        public TableINVOICE_LINE(string p_sTableName) : base(p_sTableName)
        {
        }
        // --------------------------------------------------------------------------------------
        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            var oRecords = this.DB.Select<INVOICE>("select * from INVOICE_LINE", p_iTransaction);
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
                                                    insert into invoice
                        (ID,CUSTOMER_ID, INVOICE_ID, ITEM_ID, QTY, PRICE, LINE_TOTAL )
                        values 
                        (@ID,@CUSTOMER_ID,@INVOICE_ID, @ITEM_ID, @QTY, @PRICE, @LINE_TOTAL)",

                            // Provide the update statement that will be used for updated records
                            @"
                             update INVOICE set 
                            CUSTOMER_ID = @CUSTOMER_ID,
                            INVOICE_ID = @CUSINVOICE_IDTOMER_ID
                            ITEM_ID = @ITEM_ID,
                            QTY = @QTY,
                            PRICE = @PRICE,
                            LINE_TOTAL = @LINE_TOTAL
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
