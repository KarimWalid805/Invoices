using Lib.Data;
using Lib.Data.DB;
using Invoices.Common;
using Invoices.Data.Tables;

namespace Invoices.Data
{
    public class CDataTableFactory : Dictionary<string, Type>
    {
        // [.NET] Automatic lazy initialization mechanism with the built-in Lazy class.
        // The constructor of Lazy needs a function, here an anonymous function is created with a lambda expression
        private static Lazy<CDataTableFactory> _instanceLazy = new Lazy<CDataTableFactory>(() => new CDataTableFactory());

        public static CDataTableFactory Instance { get { return _instanceLazy.Value; } }

        // ................................................................
        private CDBMSSQL _db = null!;
        public CDBMSSQL DB
        {
            get
            {
                // [PATTERNS] Lazy initialization: Establishes a DB connection on first use
                if (_db == null)
                {
                    _db = new CDBMSSQL()
                    {
                        ServerName = CSettings.Instance.DBServerURL,
                        DatabaseName = CSettings.Instance.DBName,
                        UserName = CSettings.Instance.DBUser,
                        Password = CSettings.Instance.DBPassword
                    };
                    _db.Connect();
                }
                return _db;
            }

        }
        // ................................................................



        // ----------------------------------------------------------------------------------
        public CDataTableFactory()
        {
            // [PATTERNS] Factory Method: We register classes for specified identifiers
            // so that the factory method can use them for creating table object.
            this["InvoiceLine"] = typeof(TableINVOICE_LINE);
            this["Invoice"] = typeof(TableINVOICE);
            this["ItemOrder"] = typeof(TableITEM_ORDER);
            this["Item"] = typeof(TableITEM);
            this["Supplier"] = typeof(TableSUPPLIER);
            this["Customer"] = typeof(TableCUSTOMER);
        }
        // ----------------------------------------------------------------------------------
        // [PATTERNS] Factory Method
        public IDBTable? Produce(string p_sTableIdentifier)
        {
            IDBTable? iResult = null;
            if (this.ContainsKey(p_sTableIdentifier))
            {
                // [C#] [ADVANCED] Creating an object using a class type reference.
                Type p_tTableClass = this[p_sTableIdentifier];
                Object oTable = Activator.CreateInstance(p_tTableClass)!;
                iResult = oTable as IDBTable;
                if (iResult != null)
                    iResult.DB = this.DB;
            }
            return iResult;
        }
        // ----------------------------------------------------------------------------------
    }
}
