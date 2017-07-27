namespace _05.Border_Control
{
    public class Human : ICitizen
    {
        private string name;
        private int age;
        private string id;

        public Human(string[] tokens)
        {
            this.Name = tokens[0];
            this.Age = int.Parse(tokens[1]);
            this.Id = tokens[2];
        }

        public string Name { get { return this.name; }
            private set
            {
                this.name = value;
            }
        }

        public int Age { get { return this.age; }
            private set
            {
                this.age = value;
            }
        }

        public string Id { get { return this.id; }
            private set
            {
                this.id = value;
            }
        }       
    }
}
