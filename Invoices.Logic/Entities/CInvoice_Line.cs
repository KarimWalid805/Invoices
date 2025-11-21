using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Logic;
using Invoices.Data.Records;
using System.ComponentModel.DataAnnotations;
using Lib.Common.Attribs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.ComponentModel;

namespace Invoices.Logic.Entities
{
    public class CInvoice_Line : CEntity<INVOICE_LINE>
    {
        [Key]
        public int Id { get => this.Record.ID; set => this.Record.ID = value; }
        [ForeignKey("Master")]   // [MASTER-DETAIL] This declares the master-detail relationship
        [ColumnWidth(30)]
        public int? INVOICE_ID
        {
            get
            {
                if (this.Record.INVOICE_ID == 0)
                    return -1;
                else
                    return this.Record.INVOICE_ID;
            }
            set
            {
                if (value != null)
                    this.Record.INVOICE_ID = value ?? -1;
                this.InvokePropertyChanged(nameof(INVOICE_ID));
            }
        }
        public void LookupItem(List<CItem> p_oItems)
        {
            var oFound = p_oItems.Where(x => x.ID == this.ITEM_ID).ToList();
            if (oFound.Count > 0)
                this.Item = oFound[0];
            else
                this.Item = null;
        }

        [Browsable(false)]
        public CItem? Item { get; set; } = null;
        public int ITEM_ID { get => this.Record.ITEM_ID; set => this.Record.ITEM_ID = value; }


        public int QTY { get => this.Record.QTY; set => this.Record.QTY = value; }
        public int PRICE { get => this.Record.PRICE; set => this.Record.PRICE = value; }
        public int LINE_TOTAL { get => this.Record.LINE_TOTAL; set => this.Record.LINE_TOTAL = value; }

    }
}
