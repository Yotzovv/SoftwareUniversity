using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataManipulations
{
    public class DM
    {
        public static bool IsStarSystemExisting(string name)
        {
            using (var context = new SystemContext())
            {
                return context.StarSystems.Any(n => n.Name == name);
            }
        }

        public static void CreateStarSystem(string system)
        {
            using (var context = new SystemContext())
            {
                StarSystem SS = new StarSystem()
                {
                    Name = system
                };
                context.StarSystems.Add(SS);
                context.SaveChanges();
            }
        }

        public static StarSystem GetStarSystem(string name)
        {
            using (var context = new SystemContext())
            {
                return context.StarSystems.FirstOrDefault(n => n.Name == name);
            }
        }

        public static bool HasNotExistingStar(List<Star> stars)
        {
            using (var context = new SystemContext())
            {
                bool exists = true;

                foreach (var star in stars)
                {
                    if(!context.Stars.Any(s => s.Name != star.Name))
                    {
                        exists = false;
                        break;
                    }
                }

                return exists;
            }
        }

        public static bool HasNotExistingPlanet(List<Planet> planets)
        {
            bool exists = true;

            using (var context = new SystemContext())
            {
                foreach (var planet in planets)
                {
                    if (!context.Planets.Any(p => p.Name == planet.Name))
                    {
                        exists = false;
                        break;
                    }                    
                }
            }
            return exists;
        }

        public static bool HasNotExistingAstronomer(List<Astronomer> astronomers)
        {
            bool exists = true;

            using (var context = new SystemContext())
            {
                foreach(var astronome in astronomers)
                {
                    if(!context.Astronomers.Any(a => a.FirstName == astronome.FirstName))
                    {
                        exists = false;
                        break;
                    }
                }
            }
            return exists;
        }

        public static Telescope GetTelescope(string name)
        {
            using (var context = new SystemContext())
            {
                return context.Telescopes.FirstOrDefault(t => t.Name == name);
            }
        }
    }
}
