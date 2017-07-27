namespace _02.Multiple_Implementation
{
    public class Citizen : IBirthable, IIdentifiable
    {
        private string name;
        private int age;
        public string id;
        public string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                this.age = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            private set
            {
                this.id = value;
            }
        }

        public string Birthdate
        {
            get { return this.birthdate; }
            private set
            {
                this.birthdate = value;
            }
        }
    }
}