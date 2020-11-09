using System.Collections.ObjectModel;

namespace UpdateFocusedControl
{
    public class WorkspaceViewModel : ViewModelBase
    {
        public WorkspaceViewModel()
        {
            Worksheets = new ObservableCollection<WorksheetViewModelBase>();
        }

        public ObservableCollection<WorksheetViewModelBase> Worksheets { get; }
    }

}
