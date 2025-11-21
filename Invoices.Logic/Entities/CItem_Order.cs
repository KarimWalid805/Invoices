using Invoices.Data.Records;
using Lib.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Data.Records;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Logic.Entities
{
    public class CItem_Order : CEntity<ITEM_ORDER>
    {
        [Key]
        public int ID { get => this.Record.ID; set => this.Record.ID = value; }
        public int IS_CUSTOMER_ORDER { get => this.Record.IS_CUSTOMER_ORDER; set => this.Record.IS_CUSTOMER_ORDER = value; }

        public int CUSTOMER_ID { get => this.Record.CUSTOMER_ID; set => this.Record.CUSTOMER_ID = value; }

        public int SUPPLIER_ID { get => this.Record.SUPPLIER_ID; set => this.Record.SUPPLIER_ID = value; }

        public DateTime ORDER_DATETIME { get => this.Record.ORDER_DATETIME; set => this.Record.ORDER_DATETIME = value; }

        public int STORE_CID { get => this.Record.STORE_CID; set => this.Record.STORE_CID = value; }


    }
}
