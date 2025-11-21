using Invoices.Data.Records;
using Lib.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Logic.Entities
{
    public class CCustomer : CEntity<CUSTOMER>
    {
        [Key]
        public int ID { get => this.Record.ID; set => this.Record.ID = value; }
        public int CUSTOMER_CATEGORY_CID { get => this.Record.CUSTOMER_CATEGORY_CID; set => this.Record.CUSTOMER_CATEGORY_CID = value; }

        public string CUST_NAME { get => this.Record.CUST_NAME; set => this.Record.CUST_NAME = value; }
     
    }
}
