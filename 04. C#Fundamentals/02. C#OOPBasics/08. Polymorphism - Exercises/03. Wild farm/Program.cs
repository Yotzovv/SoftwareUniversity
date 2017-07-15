using _03.Wild_farm.Models.Animals;
using _03.Wild_farm.Models.Animals.Mammals;
using _03.Wild_farm.Models.Animals.Mammals.Felimes;
using _03.Wild_farm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Wild_farm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Animal beast = null;

            while ((input = Console.ReadLine()) != "End")
            {
                var animalInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var foodInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string animalType = animalInfo[0];
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];

                    switch (animalType)
                    {
                        case "Tiger":
                            beast = new Tiger(name, animalType, weight, livingRegion);
                            break;
                        case "Zebra":
                            beast = new Zebra(name, animalType, weight, livingRegion);
                            break;
                        case "Mouse":
                            beast = new Mouse(name, animalType, weight, livingRegion);
                            break;
                        case "Cat":
                            beast = new Cat(name, animalType, animalInfo[4], weight, livingRegion);
                            break;
                        default:
                            break;
                    }

                    string foodType = foodInfo[0];
                    int quantity = int.Parse(foodInfo[1]);

                    Food food = null;

                    if (foodType == "Meat")
                    {
                        food = new Meet(quantity);
                    }
                    else
                    {
                        food = new Vegetable(quantity);
                    }

                    beast.MakeSound();
                    beast.Eat(food);


                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                Console.WriteLine(beast);
            }
        }
    }
}
