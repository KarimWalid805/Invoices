using Lib.Data;
using Lib.Logic;

namespace Lib.Logic.Visitors
{
    public class CVisitorToTable
    {
        public void VisitAddNew<T>(List<T> p_oSourceModel, IDBTable p_oDestTable) where T : IEntity, new()
        {
            foreach (var oBank in p_oSourceModel)
                if (oBank.Change == EntityChangeType.CREATED)
                    p_oDestTable.RecordSet.Add(oBank.Rec);
        }
    }
}
