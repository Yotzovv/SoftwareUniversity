using System;

namespace _05.Border_Control
{
    public class Robot : ICitizen
    {
        private string model;
        private string id;

        public Robot(string[] tokens)
        {
            this.Model = tokens[0];
            this.Id = tokens[1];
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
