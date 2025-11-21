using Lib.Data.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Records
{
    public class ITEM : CDBRecord
    {
        public int ID {  get; set; }
        public string CODE { get; set; }
        public int MEASUREMENT_UNIT_CID { get; set; }
        public int ITEM_CATEGORY_CID { get; set; }


    }
}
