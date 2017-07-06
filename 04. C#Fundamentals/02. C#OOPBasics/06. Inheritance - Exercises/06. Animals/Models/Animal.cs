﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Animals.Models
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
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
                if(value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender { get { return this.gender; }
            private set
            {
                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "Not implemented!";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(ProduceSound());

            return sb.ToString();
        }
    }
}
