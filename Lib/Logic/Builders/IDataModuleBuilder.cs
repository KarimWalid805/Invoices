using Lib.Common.Interfaces;

namespace Lib.Logic.Builders
{
    // [PATTERNS] BUILDER: The abstract builder class specifies the different steps that are needed to
    // create the composites of the product-object. Here the product is a master-detail data entry form
    public interface IDataModuleBuilder  
    {
        public IDataModule Product { get; }

        // --------------------------------------------------------------------------------
        public void BuildBrowserModel();
        // --------------------------------------------------------------------------------
        public void BuildMasterModel();
        // --------------------------------------------------------------------------------
        public void BuildDetailsModel();
        // --------------------------------------------------------------------------------
        public void BuildLookupModels();
        // --------------------------------------------------------------------------------
    }
}
