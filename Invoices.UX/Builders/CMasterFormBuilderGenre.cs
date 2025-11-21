using Invoices.Logic.Builders;
using Invoices.Logic.Modules;
using Invoices.UX.Views;
using Lib.Logic.Builders;
using Lib.UX;
using Lib.UX.Builders;
using Lib.UX.DataForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flix.UX.Builders
{
    public class CMasterFormBuilderGenre: CMasterFormBuilder
    {
        protected DMSupplier module = null!;
        protected IBrowserViewForm browserView = null!;
        protected Form entityView = null!;

        // --------------------------------------------------------------------------------
        public override void BuildDataModule()
        {
            CDataModuleDirector oDirector = new CDataModuleDirector();
            DMSupplier oModule = (DMSupplier)oDirector.ConstructDM(new CDataModuleBuilderSupplier());
            this.module = oModule;
        }
        // --------------------------------------------------------------------------------
        public override void BuildBrowserView()
        {
            this.browserView = new CViewBrowserSupplier(this.module.Browser);
        }
        // --------------------------------------------------------------------------------
        public override void BuildEntityView()
        {
            this.entityView = new CViewEntitySupplier();
        }
        // --------------------------------------------------------------------------------
        public override void BuildForm()
        {
            this.Product = new CFormTemplateMaster(module, browserView, entityView);
        }
        // --------------------------------------------------------------------------------
    }
}
