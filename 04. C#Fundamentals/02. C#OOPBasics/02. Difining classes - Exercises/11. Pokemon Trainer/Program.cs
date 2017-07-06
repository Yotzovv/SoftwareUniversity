using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Trainer> trainers = new List<Trainer>();

            while((input = Console.ReadLine()) != "Tournament")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);
                Trainer trainer = new Trainer(trainerName);

                if(trainers.Any(t => t.Name == trainerName))
                {
                    trainers.FirstOrDefault(t => t.Name == trainerName)
                            .Pokemons.Add(pokemon);
                }
                else
                {
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
            }

            while((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if(trainer.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                            
                            if(pokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(pokemon);
                                break;
                            }
                        }
                    }
                }
            }

            trainers.OrderByDescending(b => b.Badges)
                    .ToList()
                    .ForEach(t => Console.WriteLine($"{t.Name} {t.Badges} {t.Pokemons.Count}"));
        }
    }
}
