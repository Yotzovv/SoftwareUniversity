using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using Data;
using Models.Models;

namespace ExpansesManager.ViewModels
{
    public class GroupViewModel : INotifyPropertyChanged
    {
		private ExpansesManagerContext _context = new ExpansesManagerContext();

		public GroupViewModel()
        {
            this.IsActive = true;
            this.SubGroups = new ObservableCollection<SubGroupViewModel>();
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


	    public List<Group> GetGroupsList()
	    {
			
			return (from gr in _context.Groups select gr).ToList();
	    }



	    public ObservableCollection<SubGroupViewModel> SubGroups { get; set; }

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
