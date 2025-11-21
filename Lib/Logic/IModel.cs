using Lib.Logic.Visitors;

namespace Lib.Logic
{
    public interface IModel
    {
        public void AcceptVisitAfterLoad(CVisitorToModel p_oVisitor);
        public void AcceptVisitBeforeSave(CVisitorToTable p_oVisitor);
        public IEntity New();
        public void Load();
        public void Delete();
        public int Save();

    }
}
