using Flix.Logic.Entities;
using Flix.Logic.Models;
using Lib.UX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flix.UX.TableForms
{
    public partial class CTableFormMovie : CFormTemplateTable
    {
        public CMovieModel Model = new CMovieModel();

        // --------------------------------------------------------------------------------------
        public CTableFormMovie()
        {
            InitializeComponent();
        }
        // --------------------------------------------------------------------------------------
        
        #region // Virtual Methods \\
        // --------------------------------------------------------------------------------------
        protected override bool LoadModule()
        {
            // [v3] 
            Model.Load();
            // [PATTERNS] Visitor: The model is accepting a visit after loading
            Model.AcceptVisitAfterLoad(this.modelVisitor);

            return true;
        }
        // --------------------------------------------------------------------------------------
        protected override void DisplayModelEntitiesOnGrid()
        {
            // [v2]
            editableGridRecords.Populate<CMovie>(Model);
        }
        // --------------------------------------------------------------------------------------
        protected override bool SaveModule()
        {
            // [v54]
            // [PATTERNS] Visitor: The model is accepting a visit before saving
            Model.AcceptVisitBeforeSave(this.tableVisitor);

            // Saving the logic objects
            Model.Save();

            return true;
        }
        // --------------------------------------------------------------------------------------
        protected override string LastErrorMessage()
        {
            return this.Model.LastError;
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
