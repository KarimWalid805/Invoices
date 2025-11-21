using Flix.Data.Records;
using Invoices.Data.Records;
using Lib.Data.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataApplication.Data.Tables
{
    public class TableVW_INVOICE_DETAIL : CDBTable<VINVOICEDETAILS>
    {
        public TableVW_INVOICE_DETAIL() : base("ApplicationUsersView")
        {
        }
        // --------------------------------------------------------------------------------------
        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            this.records.Clear(); // Empty the existing records

            var oRecords = this.DB.Select<VINVOICEDETAILS>("select * from TableVW_INVOICE_DETAIL", p_iTransaction);

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
            {
                this.records = oRecords;

                foreach (var oRecord in this.records)
                    Debug.WriteLine(oRecord.ToString());
            }
        }
        // --------------------------------------------------------------------------------------
    }
}
