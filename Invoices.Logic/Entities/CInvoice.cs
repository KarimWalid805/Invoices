using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Common.Attribs;
using Lib.Logic;
using Invoices.Data.Records;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Invoices.Logic.Entities
{
    public class CInvoice : CEntity<INVOICE>
    {
        [Key]
        public int Id { get => this.Record.ID; set => this.Record.ID= value; }

        //make into boolean
        public int IS_CUSTOMER_INVOICE { get => this.Record.IS_CUSTOMER_INVOICE; set => this.Record.IS_CUSTOMER_INVOICE = value; }

        public int? CUSTOMER_ID {
            get
            {
                if (this.Record.CUSTOMER_ID == 0)
                    return -1;
                else
                    return this.Record.CUSTOMER_ID;
            }
            set
            {
                if (value != null)
                    this.Record.CUSTOMER_ID = value ?? -1;
                this.InvokePropertyChanged(nameof(CUSTOMER_ID));
            }
        }
        public void LookupCustomer(List<CCustomer> p_oCustomers)
        {
            var oFound = p_oCustomers.Where(x => x.ID == this.CUSTOMER_ID).ToList();
            if (oFound.Count > 0)
                this.Customer = oFound[0];
            else
                this.Customer = null;
        }

        [Browsable(false)]
        public CCustomer? Customer { get; set; } = null;
        public int SUPPLIER_ID { get => this.Record.SUPPLIER_ID; set => this.Record.SUPPLIER_ID = value; }
        public int ITEM_ORDER_ID { get => this.Record.ITEM_ORDER_ID; set => this.Record.ITEM_ORDER_ID = value; }

    }
}
