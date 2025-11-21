using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Data;
using Invoices.Logic.Entities;
using Lib.Logic.Models;

namespace Invoices.Logic.Models
{
    public class CSupplierModel : CMasterModel<CSupplier, CItem >
    {
        public CSupplierModel() : base("Supplier")
        {
            this.Table = CDataTableFactory.Instance.Produce(this.TableName)!;
        }
    }
}
