using Invoices.Logic.Builders;
using Invoices.Logic.Entities;
using Invoices.Logic.Models;
using Lib.Common.Interfaces;
using Lib.Logic;
using Lib.Logic.Models;
using Lib.Logic.Modules;


namespace Invoices.Logic.Modules
{
    public class DMInvoices : CDataModule<CInvoiceBrowserModel, CInvoiceModel, CInvoice_LineModel, CVInvoiceDetails, CInvoice, CInvoice_Line>
    {
        public override void DoOnPerformLookups(object? p_oEntity)
        {
            if (p_oEntity is CInvoice_Line line)
            {
                line.LookupItem((CItemModel)Lookups[CDataModuleBuilderInvoice.LOOKUP_ITEM]);
            }
            else if (p_oEntity is CInvoice inv)
            {
                inv.LookupItemOrder((CItem_OrderModel)Lookups[CDataModuleBuilderInvoice.LOOKUP_ITEM_ORDER]);
                inv.LookupCustomer((CCustomerModel)Lookups[CDataModuleBuilderInvoice.LOOKUP_CUSTOMER]);
            }
        }

    }
}

