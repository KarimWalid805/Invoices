namespace Lib.UX.Builders
{
    //[PATTERNS] Builder: The director has the code with the sequence of steps that builds the product-object
    public class CMasterFormDirector
    {
        protected Form? mdiParentForm = null;

        // --------------------------------------------------------------------------------
        public CMasterFormDirector(Form p_oMDIParentForm)
        {
            this.mdiParentForm = p_oMDIParentForm;
        }
        // --------------------------------------------------------------------------------
        public Form ConstructUX(CMasterFormBuilder p_oBuilder)
        {
            //[PATTERNS] BUILDER: The director instructs the builder to build the parts of the product 
            p_oBuilder.BuildDataModule();
            p_oBuilder.BuildBrowserView();
            p_oBuilder.BuildEntityView();
            p_oBuilder.BuildForm();

            // It returns the product form after making it an MDI child of the given form
            if (this.mdiParentForm != null)
                p_oBuilder.Product.MdiParent = mdiParentForm;

            return p_oBuilder.Product;
        }
        // --------------------------------------------------------------------------------

    }
}
