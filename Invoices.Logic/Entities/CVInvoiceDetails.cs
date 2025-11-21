using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Lib.Logic;
using Lib.Common.Attribs;
using Invoices.Data.Tables;
using Invoices.Data.Records;

namespace Invoices.Logic.Entities
{
    public class CVInvoiceDetails : CEntity<VINVOICEDETAILS>
    {
        // ........................................................................
        [Key]
        [ReadOnly(true)]
        [ColumnWidth(30)]
        public int InvoiceID { get => this.Record.InvoiceID; set => this.Record.InvoiceID = value; }



        [DisplayName("Customer Name")]
        [ReadOnly(true)]
        [ColumnWidth(200)]
        public string CustomerName { get => this.Record.CustomerName ?? ""; set => this.Record.CustomerName = value; }



        [ReadOnly(true)]
        [ColumnWidth(100)]
        public int ItemCode { get => this.Record.ItemCode; set => this.Record.ItemCode = value; }



        [ReadOnly(true)]
        [ColumnWidth(50)]
        public int? Quantity { get => this.Record.Quantity; set => this.Record.Quantity = value; }

        [ReadOnly(true)]
        [ColumnWidth(75)]
        public int? PricePerUnit { get => this.Record.PricePerUnit; set => this.Record.PricePerUnit = value; }



        // ........................................................................

    }
}

