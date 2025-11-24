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
        public int MasterID { get; set; }

        public TableINVOICE_LINE() : base("INVOICE_LINE") { }

        public override void LoadTable(IDbTransaction? p_iTransaction, int p_nMasterKeyValue)
        {
            this.MasterID = p_nMasterKeyValue;
            this.LoadTable(p_iTransaction);
        }

        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            this.records.Clear();

            INVOICE_LINE? oParams = new INVOICE_LINE { INVOICE_ID = this.MasterID };
            var oRecords = this.DB.SelectWithParams<INVOICE_LINE>(
                "SELECT * FROM INVOICE_LINE WHERE INVOICE_ID = @INVOICE_ID", oParams, p_iTransaction);

            if (oRecords != null)
            {
                this.records = oRecords;
                foreach (var r in this.records)
                    Debug.WriteLine(r.ToString());
            }
        }

        public override void SaveTable(IDbTransaction? p_iTransaction)
        {
            if (this.records == null) return;

            // Ensure all lines point to the correct invoice
            foreach (var rec in this.records)
                rec.INVOICE_ID = this.MasterID;

            this.DB.SaveChanges<INVOICE_LINE>(
                this.records,

                // Insert
                @"
INSERT INTO INVOICE_LINE
(INVOICE_ID, ITEM_ID, QTY, PRICE, LINE_TOTAL)
VALUES
(@INVOICE_ID, @ITEM_ID, @QTY, @PRICE, @LINE_TOTAL)
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