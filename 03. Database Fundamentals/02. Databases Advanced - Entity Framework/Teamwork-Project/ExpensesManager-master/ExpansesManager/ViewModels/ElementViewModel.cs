using System;
using System.ComponentModel;

namespace ExpansesManager.ViewModels
{
    public class ElementViewModel : INotifyPropertyChanged
    {
        public ElementViewModel()
        {
            this.dateBought = DateTime.UtcNow;
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

        private decimal price;
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (this.price != value)
                {
                    this.price = value;
                    this.OnPropertyChanged("Price");
                }
            }
        }
        private DateTime dateBought;
        public DateTime DateBought
        {
            get
            {
                return this.dateBought;
            }
            set
            {
                if (this.dateBought != value)
                {
                    this.dateBought = value;
                    this.OnPropertyChanged("DateBought");
                }
            }
        }
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
