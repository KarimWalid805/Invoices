using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Invoices.Data.Records;
using Lib.Data.Records;

namespace Invoices.Data.Tables
{
    public class TableINVOICE : CDBTable<INVOICE>
    {
        public List<INVOICE_LINE> Lines { get; set; } = new List<INVOICE_LINE>();

        public TableINVOICE() : base("INVOICE") { }

        // --------------------------------------------------------------------------------------
        public override void LoadRecord(int p_nKeyValue)
        {
            this.records.Clear();
            INVOICE? oParams = new INVOICE { ID = p_nKeyValue };

            using (var iTransaction = this.DB.BeginTransaction())
            {
                try
                {
                    var oRecords = this.DB.SelectWithParams<INVOICE>(
                        "SELECT * FROM INVOICE WHERE ID = @ID", oParams, iTransaction);
                    iTransaction.Commit();

                    if (oRecords != null)
                    {
                        this.records = oRecords;
                        foreach (var r in this.records)
                            Debug.WriteLine(r.ToString());
                    }
                }
                catch
                {
                    iTransaction.Rollback();
                    throw;
                }
            }
        }

        // --------------------------------------------------------------------------------------
        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            this.records.Clear();
            var oRecords = this.DB.Select<INVOICE>("SELECT * FROM INVOICE", p_iTransaction);
            if (oRecords != null)
            {
                this.records = oRecords;
                foreach (var r in this.records)
                    Debug.WriteLine(r.ToString());
            }
        }

        // --------------------------------------------------------------------------------------
        public override void SaveTable(IDbTransaction? p_iTransaction)
        {
            if (this.records == null) return;

            using (var transaction = this.DB.BeginTransaction())
            {
                try
                {
                    // Save invoice(s) in this transaction
                    this.DB.SaveChanges<INVOICE>(
                        this.records,
                        @"
INSERT INTO INVOICE
(IS_CUSTOMER_INVOICE, CUSTOMER_ID, SUPPLIER_ID, ITEM_ORDER_ID)
VALUES
(@IS_CUSTOMER_INVOICE, @CUSTOMER_ID, @SUPPLIER_ID, @ITEM_ORDER_ID)
SELECT CAST(SCOPE_IDENTITY() AS INT)
",
                        @"
UPDATE INVOICE SET
    IS_CUSTOMER_INVOICE = @IS_CUSTOMER_INVOICE,
    CUSTOMER_ID        = @CUSTOMER_ID,
    SUPPLIER_ID        = @SUPPLIER_ID,
    ITEM_ORDER_ID      = @ITEM_ORDER_ID
WHERE ID = @ID
",
                        "DELETE FROM INVOICE WHERE ID = @ID",
                        transaction
                    );

                    // Reload invoices without creating a new transaction
                    var invoiceIds = new List<int>();
                    foreach (var inv in this.records)
                    {
                        invoiceIds.Add(inv.ID);
                    }

                    // Save lines in the same transaction
                    foreach (var line in this.Lines)
                    {
                        // Assign the correct invoice ID
                        if (line.INVOICE_ID == 0 && invoiceIds.Count == 1)
                            line.INVOICE_ID = invoiceIds[0];
                    }

                    if (this.Lines.Count > 0)
                    {
                        this.DB.SaveChanges<INVOICE_LINE>(
                            this.Lines,
                            @"
INSERT INTO INVOICE_LINE
(INVOICE_ID, ITEM_ID, QTY, PRICE, LINE_TOTAL)
VALUES
(@INVOICE_ID, @ITEM_ID, @QTY, @PRICE, @LINE_TOTAL)
",
                            @"
UPDATE INVOICE_LINE SET
    INVOICE_ID = @INVOICE_ID,
    ITEM_ID    = @ITEM_ID,
    QTY        = @QTY,
    PRICE      = @PRICE,
    LINE_TOTAL = @LINE_TOTAL
WHERE ID = @ID
",
                            "DELETE FROM INVOICE_LINE WHERE ID = @ID",
                            transaction
                        );
                    }

                    transaction.Commit();

                    // Reload invoice table outside transaction
                    this.LoadTable(null);
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
