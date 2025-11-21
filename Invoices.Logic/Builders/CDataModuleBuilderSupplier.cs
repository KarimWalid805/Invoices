using Invoices.Data;
using Invoices.Logic.Models;
using Invoices.Logic.Modules;
using Lib.Common.Interfaces;
using Lib.Logic.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Logic.Builders
{
    public class CDataModuleBuilderSupplier: IDataModuleBuilder
    {
        protected DMInvoiceLine product = null!;
        public IDataModule Product { get { return product as IDataModule; } }


        public void BuildBrowserModel()
        {
            product = new DMInvoiceLine();
            product.Browser = new CSupplierBrowserModel();
            product.Browser.Table = CDataTableFactory.Instance.Produce(product.Browser.TableName)!;
        }

        public void BuildMasterModel()
        {
            product.Master = new CSupplierModel();
            product.Master.Table = CDataTableFactory.Instance.Produce(product.Master.TableName)!;
        }

        public void BuildDetailsModel()
        {
            product.Details = new CItem();
            product.Details.Table = CDataTableFactory.Instance.Produce(product.Details.TableName)!;
            product.Master.DetailsModel = product.Details;
        }

        public void BuildLookupModels()
        {
            // No lookups
        }

    }
}
