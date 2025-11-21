using Invoices.Logic.Entities;
using Invoices.Logic.Models;
using Lib.Logic;
using Lib.UX;
using Lib.UX.Controls;
using Lib.UX.DataForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Invoices.UX.Views
{
    public partial class CViewBrowserSupplier : Form, IBrowserViewForm
    {
        protected CFormTemplateMaster parent = null!;
        protected CSupplierBrowserModel browserModel = null!;

        // ....................................................................
        public bool HasSelectedInBrowser
        {
            get
            {
                bool bResult = false;
                if (lstGenres.SelectedItems.Count == 1)
                {
                    IEntity? oCurrentEntity = lstGenres.SelectedItems[0].Tag as IEntity;
                    if (oCurrentEntity != null)
                        bResult = oCurrentEntity.PrimaryKeyValue > 0;
                }
                return bResult;
            }
        }
        // ....................................................................
        private CGenre? _lastSelected = null;
        public IEntity? SelectedEntity 
        {   get 
            {
                _lastSelected = lstGenres.SelectedItems[0].Tag as CGenre;
                return _lastSelected as IEntity;
            }
        }
        // ....................................................................

        // --------------------------------------------------------------------------------------
        public CViewBrowserGenre(CGenreBrowserModel p_oBrowserModel)
        {
            InitializeComponent();

            this.browserModel = p_oBrowserModel;

            // Setup the list view to display large icons
            this.lstGenres.SmallImageList = this.imlGenre;
            this.lstGenres.LargeImageList = this.imlGenre;
            this.lstGenres.View = View.LargeIcon;
            this.lstGenres.FullRowSelect = true;
        }
        // --------------------------------------------------------------------------------------
        public void SetParent(Form p_oForm)
        {
            this.parent = (CFormTemplateMaster)p_oForm;
            // Sets the title on the master-detail form
            this.parent.Text = "Movie Genres";
        }
        // --------------------------------------------------------------------------------------
        public void Display(Control p_oContainer)
        {
            // [PATTERNS] Visitor. The control is a visitor here, and display method accepts the visit to this object.
            p_oContainer.DisplayView(this);
        }
        // --------------------------------------------------------------------------------------
        public void WriteBrowserListToUI()
        {
            this.lstGenres.BeginUpdate();
            this.lstGenres.Items.Clear();


            foreach (CGenre oRow in browserModel)
            {
                var item = new ListViewItem(oRow.Name);
                item.ImageIndex = oRow.CodeId - 1;
                item.SubItems.Add(oRow.Name ?? string.Empty);

                // The entity is referenced by each list view item via the tag property (we are going to need this)
                item.Tag = oRow;
                this.lstGenres.Items.Add(item);

                // Restore last selection when switching back to browser view from the entity view.
                if (_lastSelected is not null)
                    item.Selected = (_lastSelected.CodeId == oRow.CodeId);
            }

            this.lstGenres.EndUpdate();
        }

        private void DoOnAnyCommand(object sender, EventArgs e)
        {
            if (sender == this.lstGenres)
                // Trigger an open event on the parent form context, to switch to the entity view
                this.parent.FormContext.HandleEvent(this.parent.FormContext.Open);
        }
        // --------------------------------------------------------------------------------------
    }
}
