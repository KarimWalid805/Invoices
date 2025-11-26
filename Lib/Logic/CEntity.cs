using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lib.Common.Attribs;
using Lib.Data.Records;

namespace Lib.Logic
{
    //[C#/.NET]:  This is an example of a generic class where T should be a descendand of CDBRecord
    //          Additionallywe can use the class provided for T
    //          to instantiate objects of T inside a method (dynamic instantiation)

    public class CEntity<T>: IEntity where T : CDBRecord, new()
    {
        // ....................................................................
        private T _record;

        [Browsable(false)]
        public T Record { get { return _record; } set { _record = value; } }
        // ....................................................................
        [Browsable(false)]
        public int PrimaryKeyValue { get => GetPrimaryKeyValue() ?? -1; }

        [Browsable(false)]
        public int ForeignKeyOfMasterValue 
        {   get => GetForeignKeyOfMasterValue() ?? -1; 
            set => SetForeignKeyOfMasterValue(value);
        }


        // ....................................................................
        // [C#] We declare an event member. This gives the ability to a client code to hook an event handler
        public event PropertyChangedEventHandler OnPropertyChange;
        // ....................................................................


        // --------------------------------------------------------------------------------------
        public CEntity()
        {
            _record = new T();
        }
        // --------------------------------------------------------------------------------------
        protected void InvokePropertyChanged(string p_sPropertyName)
        {
            OnPropertyChange?.Invoke(this, new PropertyChangedEventArgs(p_sPropertyName));
        }
        // --------------------------------------------------------------------------------------
        // [C#/.NET] [ADVANCED]: This in an example of reflection. 
        protected int? GetPrimaryKeyValue()
        {
            int? nResult = null;

            string sResult = string.Empty;
            Type tObjectType = GetType();
            foreach (var oProperty in tObjectType.GetProperties())
            {
                var oKeyAttrib = oProperty.GetCustomAttribute<KeyAttribute>();
                if (oKeyAttrib != null)
                {
                    string sPrimaryKeyFieldName = oProperty.Name;
                    nResult = (int?)oProperty.GetValue(this);
                    break;
                }
            }
            return nResult;
        }
        // --------------------------------------------------------------------------------------
        // [C#/.NET] [ADVANCED]: This in an example of reflection. 
        protected int? GetForeignKeyOfMasterValue()
        {
            int? nResult = null;

            string sResult = string.Empty;
            Type tObjectType = GetType();
            foreach (var oProperty in tObjectType.GetProperties())
            {
                var oKeyAttrib = oProperty.GetCustomAttribute<ForeignKeyAttribute>();
                if (oKeyAttrib != null)
                {
                    if (oKeyAttrib.Name == "Master")
                    { 
                        string sPrimaryKeyFieldName = oProperty.Name;
                        nResult = (int?)oProperty.GetValue(this);
                        break;
                    }
                }
            }
            return nResult;
        }
        // --------------------------------------------------------------------------------------
        protected void SetForeignKeyOfMasterValue(int p_nValue)
        {
            Type tObjectType = GetType();
            foreach (var oProperty in tObjectType.GetProperties())
            {
                var oKeyAttrib = oProperty.GetCustomAttribute<ForeignKeyAttribute>();
                if (oKeyAttrib != null)
                {
                    if ((oKeyAttrib.Name == "Master") || (oKeyAttrib.Name == "MasterTable"))
                    {
                        oProperty.SetValue(this, p_nValue); 
                        break;
                    }
                }
            }
        }
        // --------------------------------------------------------------------------------------

        #region // IEntity \\
        // ....................................................................
        [Browsable(false)]
        public Object Rec
        {
            get => _record;
            set => _record = value as T;
        }
        // ....................................................................
        [Browsable(false)]
        public EntityChangeType Change
        {
            get
            {
                if (_record.IsDeleted)
                    return EntityChangeType.DELETED;
                else if (_record.IsNew)
                    return EntityChangeType.CREATED;
                else if (_record.IsUpdated)
                    return EntityChangeType.UPDATED;
                else
                    return EntityChangeType.NONE;
            }
            set
            {
                switch (value)
                {
                    case EntityChangeType.CREATED:
                        {
                            int? nKeyValue = GetPrimaryKeyValue();
                            if (nKeyValue != null)
                                _record.IsNew = (nKeyValue == 0);
                            else
                                _record.IsNew = true;
                            break;
                        }
                    case EntityChangeType.UPDATED:
                        {
                            _record.IsUpdated = true;
                            break;
                        }
                    case EntityChangeType.DELETED:
                        {
                            _record.IsDeleted = true;
                            break;
                        }

                }
            }
        }
        // ....................................................................
        #endregion
    }
}
