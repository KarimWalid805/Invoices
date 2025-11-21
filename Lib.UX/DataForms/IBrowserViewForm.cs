using Lib.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataForms
{
    public interface IBrowserViewForm
    {
        public void SetParent(Form p_oForm);

        public void Display(Control p_oContainer);

        public void WriteBrowserListToUI();

        public bool HasSelectedInBrowser { get; }
        public IEntity SelectedEntity { get; }
    }
}
