using Invoices.Logic.Builders;
using Invoices.Logic.Modules;
using Invoices.UX;
using Invoices.UX.Views;
using Lib.Common.Interfaces;
using Lib.Logic.Builders;
using Lib.UX;
using Lib.UX.Builders;
using Lib.UX.DataForms;

namespace Invoices.UX.Builders
{
    // [PATTERNS] Builder: This is an example of a concrete builder where the abstract builder is the ancestor class
    public class CMasterFormBuilderInvoice: CMasterFormBuilder
    {
        protected DMInvoices module = null!;
        protected IBrowserViewForm browserView = null!;
        protected Form entityView = null!;

        // --------------------------------------------------------------------------------
        public override void BuildDataModule()
        {
            CDataModuleDirector oDirector = new CDataModuleDirector();
            DMInvoices oModule = (DMInvoices)oDirector.ConstructDM(new CDataModuleBuilderInvoice());
            this.module = oModule;
        }
        // --------------------------------------------------------------------------------
        public override void BuildBrowserView()
        {
            this.browserView = new CViewBrowserInvoice(this.module.Browser);
        }
        // --------------------------------------------------------------------------------
        public override void BuildEntityView()
        {
            this.entityView = new CViewEntityInvoice();
        }
        // --------------------------------------------------------------------------------
        public override void BuildForm()
        {
            this.Product = new CFormTemplateMaster(module, browserView, entityView);
        }
        // --------------------------------------------------------------------------------
    }
}
