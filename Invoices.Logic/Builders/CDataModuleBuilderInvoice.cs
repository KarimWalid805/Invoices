using Invoices.Data;
using Invoices.Logic.Models;
using Invoices.Logic.Modules;
using Lib.Common.Interfaces;
using Lib.Logic.Builders;
using Lib.Logic.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Logic.Builders
{
    // [PATTERNS] Builder: This is an example of a concrete builder where the abstract builder is an interface
    public class CDataModuleBuilderInvoice : IDataModuleBuilder
    {
        protected DMInvoices product = null!;

        # region // IDataModuleBuilder \\
        public IDataModule Product { get { return product as IDataModule; } }

        // -----------------------------------------------------------------------------------------------
        public void BuildBrowserModel()
        {
            product = new DMInvoices();
            product.Browser = new CInvoiceBrowserModel();
            product.Browser.Table = CDataTableFactory.Instance.Produce(product.Browser.TableName)!;
        }
        // -----------------------------------------------------------------------------------------------
        public void BuildMasterModel()
        {
            product.Master = new CInvoiceModel();
            product.Master.Table = CDataTableFactory.Instance.Produce(product.Master.TableName)!;

        }
        // -----------------------------------------------------------------------------------------------
        public void BuildDetailsModel()
        {
            product.Details = new CInvoice_LineModel();
            product.Details.Table = CDataTableFactory.Instance.Produce(product.Details.TableName)!;
            product.Master.DetailsModel = product.Details;
        }
        // -----------------------------------------------------------------------------------------------

        public const int LOOKUP_ITEM_ORDER = 0;
        public const int LOOKUP_ITEM = 1;
        public const int LOOKUP_CUSTOMER = 2;



        public void BuildLookupModels()
        {

            CItem_OrderModel oLookup1 = new CItem_OrderModel();  // [C#] Variant Types. This is a feature to turn C# into Python, don't misuse it!
            oLookup1.Table = CDataTableFactory.Instance.Produce(oLookup1.TableName)!;

            CItemModel oLookup2 = new CItemModel();
            oLookup2.Table = CDataTableFactory.Instance.Produce(oLookup2.TableName)!;

            CCustomerModel oLookup3 = new CCustomerModel();
            oLookup2.Table = CDataTableFactory.Instance.Produce(oLookup2.TableName)!;

            product.Lookups.Add(oLookup1);
            product.Lookups.Add(oLookup2);
            product.Lookups.Add(oLookup3);
        }
        // -----------------------------------------------------------------------------------------------
        #endregion
       
    }
}
