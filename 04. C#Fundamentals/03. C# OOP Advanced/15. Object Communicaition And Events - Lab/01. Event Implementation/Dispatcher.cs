using System;

namespace _01.Event_Implementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
    
    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;
        private string name;

        public string Name { get { return this.name; }
            set
            {
                this.name = value;

                OnNameChange(new NameChangeEventArgs(value));
            }
        }


        public void OnNameChange(NameChangeEventArgs args)
        {
            if(NameChange != null)
            {
                NameChange(this, args);
            }
        }
    }
}
