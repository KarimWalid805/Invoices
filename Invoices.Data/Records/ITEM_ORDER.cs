using Lib.Data.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Records
{
    public class ITEM_ORDER : CDBRecord
    {
        public int ID { get; set; }
        public int IS_CUSTOMER_ORDER { get; set; }
        public int CUSTOMER_ID { get; set; }
        public int SUPPLIER_ID { get; set; }
        public DateTime ORDER_DATETIME { get; set; }
        public int STORE_CID { get; set; }
    }
}
