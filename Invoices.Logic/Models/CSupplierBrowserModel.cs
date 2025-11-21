using Invoices.Data;
using Invoices.Logic.Entities;

using Lib.Logic.Models;

namespace Invoices.Logic.Models
{
    public class CSupplierBrowserModel : CTableModel<CInvoice_Line>
    {
        public CSupplierBrowserModel() : base("ViewSupplier")
        {
            this.Table = CDataTableFactory.Instance.Produce(this.TableName)!;
        }
    }
}
