using Invoices.Data.Records;
using Lib.Logic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace Invoices.Logic.Entities
{
    public class CInvoice : CEntity<INVOICE>
    {
        [Key]
        public int Id
        {
            get => this.Record.ID;
            set
            {
                this.Record.ID = value;
                this.InvokePropertyChanged(nameof(Id));
            }
        }

       
        public int IS_CUSTOMER_INVOICE
        {
            get => this.Record.IS_CUSTOMER_INVOICE;
            set
            {
                this.Record.IS_CUSTOMER_INVOICE = value;
                this.InvokePropertyChanged(nameof(IS_CUSTOMER_INVOICE));
            }
        }



        // Nullable wrapper that exposes -1 as "no value" to match UI usage
        public int? CUSTOMER_ID
        {
            get { return this.Record.CUSTOMER_ID ?? -1; }
            set
            {
                if (value == -1)
                    this.Record.CUSTOMER_ID = null;
                else
                    this.Record.CUSTOMER_ID = value;
                InvokePropertyChanged(nameof(CUSTOMER_ID));
            }
        }

        public int ITEM_ORDER_ID
        {
            get { return this.Record.ITEM_ORDER_ID ?? -1; }
            set
            {
                if (value == -1)
                    this.Record.ITEM_ORDER_ID = null;
                else
                    this.Record.ITEM_ORDER_ID = value;
                InvokePropertyChanged(nameof(ITEM_ORDER_ID));
            }
        }

        public void LookupItemOrder(List<CItem_Order> p_oItem_Order)
        {
            var oFound = p_oItem_Order.Where(x => x.ID == this.ITEM_ORDER_ID).ToList();
            if (oFound.Count > 0)
                this.ITEM_ORDER = oFound[0];
            else
                this.ITEM_ORDER = null;
        }

        public void LookupCustomer(List<CCustomer> p_oCustomer)
        {
            if (this.CUSTOMER_ID.HasValue)
            {
                this.CUSTOMER = p_oCustomer.FirstOrDefault(x => x.ID == this.CUSTOMER_ID.Value);
            }
            else
            {
                this.CUSTOMER = null;
            }
        }


        public int SUPPLIER_ID
       
        {
            get { return this.Record.SUPPLIER_ID ?? -1; }
            set
            {
                if (value == -1)
                    this.Record.SUPPLIER_ID = null;
                else
                    this.Record.SUPPLIER_ID = value;
                InvokePropertyChanged(nameof(SUPPLIER_ID));
            }
        }

        public CCustomer? CUSTOMER { get; set; } = null;
        public CItem_Order? ITEM_ORDER { get; set; } = null;
        
    }
}