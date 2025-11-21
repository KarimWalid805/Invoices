using Lib.Data.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Records
{
    public class VINVOICEDETAILS : CDBRecord
    {
        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }
        public int ItemCode { get; set; }
        public int? Quantity { get; set; }
        public int? PricePerUnit { get; set; }
    }
}
