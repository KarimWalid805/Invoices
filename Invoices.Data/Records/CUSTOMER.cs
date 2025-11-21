using Lib.Data.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Records
{
    public class CUSTOMER : CDBRecord
    {
        public int ID { get; set; }
        public int CUSTOMER_CATEGORY_CID { get; set; }
        public string CUST_NAME { get; set; }
    }
}
