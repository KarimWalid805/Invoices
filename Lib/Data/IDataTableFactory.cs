using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public interface IDataTableFactory
    {
        public IDBTable? Produce(string p_sTableIdentifier);
    }
}
