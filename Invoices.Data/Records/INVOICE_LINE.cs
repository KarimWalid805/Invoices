using Lib.Data.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Records
{
    public class INVOICE_LINE : CDBRecord
    {
        [Key]

        public int ID { get; set; }
        public int INVOICE_ID { get; set; }
        public int ITEM_ID { get; set; }
        public int QTY { get; set; }
        public int PRICE { get; set; }
        public int LINE_TOTAL { get; set; }
    }
}
