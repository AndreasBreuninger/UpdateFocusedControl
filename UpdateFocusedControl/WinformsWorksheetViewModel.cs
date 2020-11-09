using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace UpdateFocusedControl
{
    public class WinformsWorksheetViewModel : WorksheetViewModelBase
    {
        public WindowsFormsHost Form { get; }

        public WinformsWorksheetViewModel(Control form)
        {
            Form = new WindowsFormsHost();

            try
            {
                Form.Child = form;
            }
            catch (Exception)
            {
                // ignored
            }

        }
    }
}
