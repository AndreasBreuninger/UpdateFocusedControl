using System.Windows.Controls;

namespace UpdateFocusedControl
{
    public class WpfWorksheetViewModel : WorksheetViewModelBase
    {
        public ContentControl Form { get; set; }

        public WpfWorksheetViewModel(ContentControl form)
        {
            Form = form;
        }
    }
}
