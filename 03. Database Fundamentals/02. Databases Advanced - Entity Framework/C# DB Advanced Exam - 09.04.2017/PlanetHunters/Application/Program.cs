using Data;
using Data.DataManipulations;
using Data.Dtos;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.InitializeDB();

            ImportJson();
            XmlImport();
        }

        private static void XmlImport()
        {
            using (var context = new SystemContext())
            {
                //ImportStars(context);
                ImportDiscoveries(context);
            }
        }

        private static void ImportDiscoveries(SystemContext context)
        {
            var xml = XDocument.Load("../../Xml/discoveries.xml");
            XElement discoveries = xml.Root;

            foreach (var discovery in discoveries.Elements())
            {
                DateTime dateMade = DateTime.Parse(discovery.Attribute("DateMade").Value);
                List<Star> stars = discovery.Elements("Stars").Cast<Star>().ToList();
                List<Planet> planets = discovery.Elements("Planets").Cast<Planet>().ToList();
                List<Astronomer> pioneers = discovery.Elements("Pioneers").Cast<Astronomer>().ToList();
                List<Astronomer> observers = discovery.Elements("Observers").Cast<Astronomer>().ToList();
                string telescopeUsed = discovery.Attribute("Telescope").Value;

                if (DM.HasNotExistingAstronomer(pioneers) || DM.HasNotExistingAstronomer(observers)
                    || DM.HasNotExistingPlanet(planets) || DM.HasNotExistingStar(stars))
                {
                    continue;
                }

                Discovery dis = new Discovery()
                {
                    Date = dateMade,
                    Stars = stars,
                    Pioneers = pioneers,
                    Observers = observers,
                    Planets = planets,
                    TelescopeUsed = DM.GetTelescope(telescopeUsed),
                };

                Console.WriteLine($"Successfully imported discovery.");
                context.Discoveries.Add(dis);
            }
            context.SaveChanges();
        }

        private static void ImportStars(SystemContext context)
        {
            var xml = XDocument.Load("../../Import/Xml/stars.xml");
            XElement import = xml.Root;

            foreach (var star in import.Elements())
            {
                string name = star.Element("Name").Value;
                int temperature = int.Parse(star.Element("Temperature").Value);
                string starSystem = star.Element("StarSystem").Value;

                if(temperature > 2400)
                {
                    if (!DM.IsStarSystemExisting(starSystem))
                    {
                        DM.CreateStarSystem(starSystem);
                    }

                    var ss = DM.GetStarSystem(starSystem);

                    Star s = new Star()
                    {
                        Name = name,
                        Temperature = temperature,
                        StarSystem = ss,
                    };
                    Console.WriteLine($"Record {name} successfully imported.");
                    context.Stars.Add(s);
                    context.StarSystems.FirstOrDefault(w => w.Name == ss.Name).Stars.Add(s);
                }
                else
                {
                    Console.WriteLine("Error: Invalid data.");
                }  
            }
            context.SaveChanges();
        }
            

        private static void ImportJson()
        {
            using (var context = new SystemContext())
            {
                //ImportAstronomers(context);
                //ImportTelescopes(context);
                //ImportPlanets(context);
            }
        }

        private static void ImportPlanets(SystemContext context)
        {
            var json = File.ReadAllText("../../Import/Json/planets.json");
            var planetsDto = JsonConvert.DeserializeObject<List<PlanetDto>>(json);

            foreach (var planetDto in planetsDto)
            {
                if(planetDto.Mass > 0)
                {
                    if (!DM.IsStarSystemExisting(planetDto.Name))
                    {
                        DM.CreateStarSystem(planetDto.StarSystem);
                    }
                    var starSystem = DM.GetStarSystem(planetDto.StarSystem);

                    Planet planet = new Planet()
                    {
                        Name = planetDto.Name,
                        Mass = planetDto.Mass,
                        StarSystem = starSystem,
                    };

                    context.Planets.Add(planet);
                    context.StarSystems.FirstOrDefault(ss => ss.Name == starSystem.Name).Planets.Add(planet);
                    context.SaveChanges();

                    Console.WriteLine($"Record {planetDto.Name} successfully imported.");
                }
                else
                {
                    Console.WriteLine("Error: Invalid data input.");
                }
            }
        }

        private static void ImportTelescopes(SystemContext context)
        {
            var json = File.ReadAllText("../../Import/Json/telescopes.json");
            var telescopes = JsonConvert.DeserializeObject<List<TelescopeDto>>(json);

            foreach (var telescope in telescopes)
            {
                if(telescope.Location != null && telescope.Name != null && telescope.MirrorDiameter > 0.0)
                {
                    Telescope t = new Telescope()
                    {
                        Name = telescope.Name,
                        Location = telescope.Location,
                        MirrorDiameter = telescope.MirrorDiameter
                    };
                   
                    context.Telescopes.Add(t);
                    Console.WriteLine($"Record {telescope.Name} successfully imported.");
                }
                else
                {
                    Console.WriteLine("Invalid data format.");
                }
            }
            context.SaveChanges();
        }

        private static void ImportAstronomers(SystemContext context)
        {
            var json = File.ReadAllText("../../Import/Json/astronomers.json");
            var astronomers = JsonConvert.DeserializeObject<List<Astronomer>>(json);

            foreach (var astronome in astronomers)
            {
                if(astronome.FirstName != null && astronome.LastName != null)
                {
                    context.Astronomers.Add(astronome);
                    Console.WriteLine($"Record {astronome.FirstName} {astronome.LastName} successfully imported.");
                }
                else
                {
                    Console.WriteLine("Invalid data format.");
                }
            }
            context.SaveChanges();
        }
    }
}
