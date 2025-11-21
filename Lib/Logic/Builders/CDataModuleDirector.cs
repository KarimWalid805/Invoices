using Lib.Common.Interfaces;
using Lib.Logic.Modules;

namespace Lib.Logic.Builders
{
    //[PATTERNS] Builder: The director has the code with the sequence of steps that builds the product-object
    public class CDataModuleDirector
    {
        // --------------------------------------------------------------------------------
        public CDataModuleDirector()
        {
        }
        // --------------------------------------------------------------------------------
        public IDataModule ConstructDM(IDataModuleBuilder p_oBuilder)
        {
            //[PATTERNS] BUILDER: The director instructs the builder to build the parts of the product 
            p_oBuilder.BuildBrowserModel();
            p_oBuilder.BuildMasterModel();
            p_oBuilder.BuildDetailsModel();
            p_oBuilder.BuildLookupModels();

            return p_oBuilder.Product;
        }
        // --------------------------------------------------------------------------------

    }
}
