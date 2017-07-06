using System.Collections.ObjectModel;
using System.ComponentModel;
using Models.Models;

namespace ExpansesManager.ViewModels
{
    public class SubGroupViewModel : INotifyPropertyChanged
    {
        public SubGroupViewModel()
        {
            this.IsActive = true;
            this.Elements = new ObservableCollection<ElementViewModel>();
        }
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (this.id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (this.name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private bool isActive;
        public bool IsActive
        {
            get
            {
                return this.isActive;
            }
            set
            {
                if (this.isActive != value)
                {
                    this.isActive = value;
                    this.OnPropertyChanged("IsActive");
                }
            }
        }


        public ObservableCollection<ElementViewModel> Elements { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
