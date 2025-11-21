namespace Lib.UX.Builders
{
    // [PATTERNS] BUILDER: The abstract builder class specifies the different steps that are needed to
    // create the composites of the product-object. Here the product is a master-detail data entry form
    public class CMasterFormBuilder
    {
        public Form Product { get; set; } = null!;

        // --------------------------------------------------------------------------------
        public virtual void BuildDataModule()
        {
            // Override this on the concrete descendant class, to write the code that creates and initializes a custom data module.
            throw new NotImplementedException();
        }
        // --------------------------------------------------------------------------------
        public virtual void BuildBrowserView()
        {
            // Override this on the concrete descendant class, to write the code that creates a custom browser view
            throw new NotImplementedException();
        }
        // --------------------------------------------------------------------------------
        public virtual void BuildEntityView()
        {
            // Override this on the concrete descendant class,  to write the code that creates a custom entity view
            throw new NotImplementedException();
        }
        // --------------------------------------------------------------------------------
        public virtual void BuildForm()
        {
            // Override this on the concrete descendant class, to write the custom code that creates the master detail form
            throw new NotImplementedException();
        }
        // --------------------------------------------------------------------------------

    }
}
