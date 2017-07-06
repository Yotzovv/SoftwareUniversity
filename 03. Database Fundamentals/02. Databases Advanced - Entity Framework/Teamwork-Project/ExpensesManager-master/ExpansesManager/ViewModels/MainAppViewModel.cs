using System.Collections.ObjectModel;
using ExpansesManager.ViewModels;

namespace ExpansesManager
{
    public class MainAppViewModel
    {
        public MainAppViewModel()
        {
            this.Groups = new ObservableCollection<GroupViewModel>();
        }

        public ObservableCollection<GroupViewModel> Groups { get; set; }
    }
}
