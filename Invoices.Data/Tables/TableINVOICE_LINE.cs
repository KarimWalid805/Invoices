using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Invoices.Data.Records;
using Lib.Data.Records;

namespace Invoices.Data.Tables
{
    public class TableINVOICE_LINE : CDBTable<INVOICE_LINE>
    {
     

        public TableINVOICE_LINE() : base("INVOICE_LINE") { }

        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            var oRecords = this.DB.Select<INVOICE_LINE>("select * from INVOICE_LINE", p_iTransaction);

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
            {
                this.records = oRecords;

                foreach (var oRecord in this.records)
                    Debug.WriteLine(oRecord.ToString());
            }
        }

        public override void LoadTable(IDbTransaction? p_iTransaction, int p_nMasterKeyValue)
        {
            this.records.Clear();

            INVOICE_LINE? oParams = new INVOICE_LINE { };
            oParams.INVOICE_ID = p_nMasterKeyValue;
            var oRecords = this.DB.SelectWithParams<INVOICE_LINE>(
                "SELECT * FROM INVOICE_LINE WHERE INVOICE_ID = @INVOICE_ID", oParams, p_iTransaction);

            if (oRecords != null)
            {
                this.records = oRecords;
                foreach (var r in this.records)
                    Debug.WriteLine(r.ToString());
            }
        }

        public override void SaveTable(IDbTransaction p_iTransaction)
        {
            if (this.records != null)
            {
                this.DB.SaveChanges<INVOICE_LINE>(
                   this.records,

                   // Insert
                   @"
INSERT INTO INVOICE_LINE
( INVOICE_ID, ITEM_ID, QTY, PRICE, LINE_TOTAL)
VALUES
( @INVOICE_ID, @ITEM_ID, @QTY, @PRICE, @LINE_TOTAL);
",

                   // Update
                   @"
UPDATE INVOICE_LINE SET
    INVOICE_ID = @INVOICE_ID,
    ITEM_ID    = @ITEM_ID,
    QTY        = @QTY,
    PRICE      = @PRICE,
    LINE_TOTAL = @LINE_TOTAL
WHERE ID = @ID
",



                   // Delete
                   "DELETE FROM INVOICE_LINE WHERE ID = @ID",

                   p_iTransaction
               );

                this.LoadTable(p_iTransaction);
            }

           

        }
    }
}