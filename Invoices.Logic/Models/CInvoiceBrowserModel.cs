using Invoices.Data;
using Invoices.Data.Records;
using Invoices.Logic;
using Invoices.Logic.Entities;
using Lib.Logic.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Logic.Models
{
    public class CInvoiceBrowserModel : CTableModel<CVInvoiceDetails>
    {
        // ....................................................................
        private Dictionary<string, object> _criteria = new Dictionary<string, object>();
        public Dictionary<string, object> Criteria { get { return _criteria; } }


        public CInvoiceBrowserModel() : base("ViewInvoices")
        {
            this.Table = CDataTableFactory.Instance.Produce(this.TableName)!;
        }
    }
}
