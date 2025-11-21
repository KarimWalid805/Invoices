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
    public class CSupplier : CEntity<SUPPLIER>
    {
        [Key]
        public int ID { get => this.Record.ID; set => this.Record.ID = value; }
        public int SUPPLIER_CATEGORY_ID { get => this.Record.SUPPLIER_CATEGORY_ID; set => this.Record.SUPPLIER_CATEGORY_ID = value; }

    }
}
