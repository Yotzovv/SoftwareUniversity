using System;

namespace _06.Birthday_Celebrations
{
    public class Robot : ICitizen
    {
        private string model;
        private string id;

        public Robot(string[] tokens)
        {
            this.Model = tokens[1];
            this.Id = tokens[2];
        }

        public string Model { get { return this.model; }
            private set
            {
                this.model = value;
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
