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
       

        public TableINVOICE() : base("INVOICE") { }

        // --------------------------------------------------------------------------------------
        public override void LoadRecord(int p_nKeyValue)
        {
            this.records.Clear();
            INVOICE? oParams = new INVOICE { ID = p_nKeyValue };
            oParams.ID = p_nKeyValue;

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
            if (this.records == null)
            {
                
                    // Save invoice(s) in this transaction
                    this.DB.SaveChanges<INVOICE>(
                        this.records,
                        @"
INSERT INTO INVOICE
(IS_CUSTOMER_INVOICE, CUSTOMER_ID, SUPPLIER_ID, ITEM_ORDER_ID)
VALUES
(@IS_CUSTOMER_INVOICE, @CUSTOMER_ID, @SUPPLIER_ID, @ITEM_ORDER_ID)


",
                        @"
UPDATE INVOICE SET
    IS_CUSTOMER_INVOICE = @IS_CUSTOMER_INVOICE,
    CUSTOMER_ID        = @CUSTOMER_ID,
    SUPPLIER_ID        = @SUPPLIER_ID,
    ITEM_ORDER_ID      = @ITEM_ORDER_ID
WHERE ID = @ID
",
                        @"DELETE FROM INVOICE WHERE ID = @ID",
                        p_iTransaction
                    );




                    // We reload the table to reflect all the changes that have been saved in the DB
                    // With this we secure that fields altered by DB triggers are properly loaded
                    this.LoadTable(p_iTransaction);
                }

            }

        }
    }

