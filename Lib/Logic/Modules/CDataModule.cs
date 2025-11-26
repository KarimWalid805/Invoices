using Lib.Logic;
using Lib.Logic.Models;
using Lib.Common.Interfaces;
using Lib.Logic.Visitors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Logic.Modules
{
    // [C#] [ADVANCED GENERICS] We can forward a generic class type from a placeholder to another generic class placeholder (e.g. in CBaseModel<T> will copy EB to T)
    public class CDataModule<B, M, D, EB, EM, ED> : IDataModule 
        where B: CBaseModel<EB>
            where EB : IEntity, new()
        where M : CMasterModel<EM, ED>
            where EM : IEntity, new()
        where D : CBaseModel<ED>
            where ED : IEntity, new()
    {
        // ..................................................................
        protected B browser;
        public B Browser { get { return browser; } set { browser = value; } }
        // ..................................................................
        protected M master;
        public M Master { get { return master; } set { master = value; } }
        // ..................................................................
        public EM MasterEntity
        {
            get { return master.MasterEntity; }
        }
        // ..................................................................
        protected D details;
        public D Details { get { return details; } set { details = value; } }
        // ..................................................................
        protected List<IModel> lookups = new List<IModel>();
        public List<IModel> Lookups { get { return lookups; } }
        // ..................................................................

        protected CVisitorToModel modelVisitor = new CVisitorToModel();
        protected CVisitorToTable tableVisitor = new CVisitorToTable();

        // ----------------------------------------------------------------------------------
        public CDataModule()
        {
        }
        // ----------------------------------------------------------------------------------

        #region // IDataModule \\
        public int MasterKeyValue
        {
            get
            {
                return this.master.MasterKey;
            }
            set
            {
                this.master.MasterKey = value;
            }
        }

        public string LastError { get; set; } = null!;
        public bool IsLoaded { get; set; }

        // ----------------------------------------------------------------------------------
        public virtual void DoOnPerformLookups(object? p_oEntity)
        {
        }
        // ----------------------------------------------------------------------------------
        // [PATTERNS] Template method
        public void ModuleOnAnyEntityChange(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != null)
                DoOnPerformLookups(sender);
        }
        // ----------------------------------------------------------------------------------
        public bool ModuleLoadBrowser()
        {
            bool bResult = false;
            try
            {
                this.browser.Load();
                this.browser.AcceptVisitAfterLoad(this.modelVisitor);
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // ----------------------------------------------------------------------------------
        public bool ModuleLoadLookups()
        {
            bool bResult = false;
            try
            {
                foreach (IModel iModel in this.lookups)
                {
                    iModel.Load();
                    iModel.AcceptVisitAfterLoad(this.modelVisitor);
                }
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // ----------------------------------------------------------------------------------
        public virtual bool ModuleNew()
        {
            IEntity iEntity = this.master.New();
            iEntity.OnPropertyChange += ModuleOnAnyEntityChange;
            return true;
        }
        // ----------------------------------------------------------------------------------
        // [PATTERNS] Template method
        public bool ModuleLoad()
        {
            bool bResult = false;
            try
            {

                this.master.Load();
                this.modelVisitor.EntityChangeHandler = ModuleOnAnyEntityChange;
                this.master.AcceptVisitAfterLoad(this.modelVisitor);
                this.details.AcceptVisitAfterLoad(this.modelVisitor);

                // Lookup the movie form its Id for every detail record
                foreach (var oDetail in this.details)
                    DoOnPerformLookups(oDetail);

                this.IsLoaded = true;
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // ----------------------------------------------------------------------------------
        public bool ModuleDelete()
        {
            bool bResult = false;
            try
            {
                this.master.Delete();
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // ----------------------------------------------------------------------------------
        public bool ModuleSave()
        {
            bool bResult = false;
            try
            {
                this.master.AcceptVisitBeforeSave(this.tableVisitor);
                this.details.AcceptVisitBeforeSave(this.tableVisitor);
                this.master.Save();
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // ----------------------------------------------------------------------------------

        #endregion
    }
}
