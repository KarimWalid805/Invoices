using Lib.Data.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Records
{
    public class SUPPLIER : CDBRecord
    {
        public int ID { get; set; }
        public int SUPPLIER_CATEGORY_ID { get; set; }
    }
}
