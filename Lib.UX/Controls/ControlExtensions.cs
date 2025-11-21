using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.Controls
{
    //[C#]: This is an example of a static class. Such a class contains only class (static) methods and cannot be used to create objects
    public static class ControlExtensions
    {
        //[C#]: This is an example of an extension method. These are object (non-static) methods that are added as plugins to existing classes.
        //      To create this plugin method, we need to declare it as a static with the keyword `this` at the start of the parameter list.
        //      The class on which this plugin will be added is declared in the method's header after the keyword `this`.

        // This adds to the Control a method DisplayView().
        // An object oControl of this class can call oControl.DisplayView(oView)
        public static void DisplayView(this Control p_oContainer, Form p_oView)
        {
            // Hide all other controls in the given container
            foreach (Control oControl in p_oContainer.Controls)
                oControl.Visible = false;

            // [.NET WINFORMS | ADVANCED] Hosting a form inside a container control
            p_oView.TopLevel = false;
            p_oView.FormBorderStyle = FormBorderStyle.None;
            p_oView.Dock = DockStyle.Fill;
            p_oContainer.Controls.Add(p_oView);
            p_oView.Show();
        }
    }
}
