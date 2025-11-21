using Invoices.Data;
using Invoices.Logic.Entities;

using Lib.Logic.Models;

namespace Invoices.Logic.Models
{
    public class CInvoice_LineBrowserModel : CTableModel<CInvoice_Line>
    {
        public CInvoice_LineBrowserModel() : base("ViewInvoice")
        {
            this.Table = CDataTableFactory.Instance.Produce(this.TableName)!;
        }
    }
}
