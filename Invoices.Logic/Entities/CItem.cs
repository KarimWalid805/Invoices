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
    public class CItem : CEntity<ITEM>
    {
        [Key]
        public int ID { get => this.Record.ID; set => this.Record.ID = value; }
        public string CODE { get => this.Record.CODE; set => this.Record.CODE = value; }

        public int MEASUREMENT_UNIT_CID { get => this.Record.MEASUREMENT_UNIT_CID; set => this.Record.MEASUREMENT_UNIT_CID = value; }

        public int ITEM_CATEGORY_CID { get => this.Record.ITEM_CATEGORY_CID; set => this.Record.ITEM_CATEGORY_CID = value; }
    }
}

