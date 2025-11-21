using Flix.Logic.Builders;
using Flix.Logic.Modules;
using Flix.UX.Views;
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
        protected DMGenre module = null!;
        protected IBrowserViewForm browserView = null!;
        protected Form entityView = null!;

        // --------------------------------------------------------------------------------
        public override void BuildDataModule()
        {
            CDataModuleDirector oDirector = new CDataModuleDirector();
            DMGenre oModule = (DMGenre)oDirector.ConstructDM(new CDataModuleBuilderGenre());
            this.module = oModule;
        }
        // --------------------------------------------------------------------------------
        public override void BuildBrowserView()
        {
            this.browserView = new CViewBrowserGenre(this.module.Browser);
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
