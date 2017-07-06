using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] inputPeople = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in inputPeople)
            {
                string name = person.Split('=')[0];
                decimal money = decimal.Parse(person.Split('=')[1]);

                try
                {
                    Person p = new Person(name, money);
                    people.Add(p);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            foreach (var product in inputProducts)
            {
                string name = product.Split('=')[0];
                decimal cost = decimal.Parse(product.Split('=')[1]);

                try
                {
                    Product p = new Product(name, cost);
                    products.Add(p);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            }


            while((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Person person = people.FirstOrDefault(n => n.Name == tokens[0]);
                    Product product = products.FirstOrDefault(n => n.Name == tokens[1]);


                    if (product.Cost > person.Money)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} bought {product.Name}");

                        person.Money -= product.Cost;
                        person.Bag.Add(product);
                    }
                }
                catch
                {
                    
                }
            }

            people.ForEach(p => Console.WriteLine(p));          
        }
    }
}
