using CarDealer;
using CarDealer.A.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            Queries(context);   
        }

        private static void Queries(Context context)
        {
            //Cars(context);
            //Ferrari(context);
            //LocalSuppliers(context);
            //CarsParts(context);
            //TotalSalesByCustomer(context);
            SalesWithAppliedDiscount(context);
        }

        private static void SalesWithAppliedDiscount(Context context)
        {
            var sales = context.Sales.Select(s => new
            {
                CarMake = s.Car.Make,
                CarModel = s.Car.Model,
                CarTravelledDistance = s.Car.TravelledDistance,
                CustomerName = s.Customer.Name,
                Discount = s.Discount,
                Price = s.Car.Parts.Sum(p => p.Price),
                PriceWithDiscount = s.Car.Parts.Sum(p => p.Price) - (s.Car.Parts.Sum(p => p.Price) * (s.Discount / 100))
            }).ToList();

            var xml = new XElement("sales", sales.Select(s => new XElement("sale",
                new XElement("car", 
                new XAttribute("make", s.CarMake),
                new XAttribute("model", s.CarModel),
                new XAttribute("travelled-distance", s.CarTravelledDistance)),
                new XElement("customer-name", s.CustomerName),
                new XElement("discount", s.Discount),
                new XElement("price", s.Price),
                new XElement("price-with-discount", s.PriceWithDiscount)))).ToString();

            File.WriteAllText("../../Import/SalesWithAppliedDiscount.xml", xml);
        }

        private static void TotalSalesByCustomer(Context context)
        {
            var customers = context.Customers.Where(c => c.Sales.Count > 0)
                                             .Select(c => new CustomerDto
                                             {
                                                 Name = c.Name,
                                                 BoughtCars = c.Sales.Count,
                                                 SpentMoney = c.Sales.Sum(p => p.Car.Parts.Sum(x => x.Price))
                                             })
                                             .OrderByDescending(m => m.SpentMoney)
                                             .ThenByDescending(bc => bc.BoughtCars)
                                             .ToList();
            var stream = new FileStream("TotalSalesByCustomer.xml", FileMode.Create);
            var xml = new XmlSerializer(customers.GetType(), new XmlRootAttribute("customers"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (stream)
            {
                xml.Serialize(stream, customers, ns);
            }
        }

        private static void CarsParts(Context context)
        {
            var cars = context.Cars.Select(c => new CarDto
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                Parts = c.Parts.Select(p => new PartDto
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            }).ToList();

            var stream = new FileStream("CarsListParts.xml", FileMode.Create);
            var xml = new XmlSerializer(cars.GetType(), new XmlRootAttribute("cars"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (stream)
            {
                xml.Serialize(stream, cars, ns);
            }
        }

        private static void LocalSuppliers(Context context)
        {
            var suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                                             .Select(s => new SupplierDto
                                             {
                                                 Id = s.Id,
                                                 Name = s.Name,
                                                 PartsCount = s.Parts.Count
                                             }).ToList();
            var fileStream = new FileStream("LocalSuppliers.xml", FileMode.Create);
            var xml = new XmlSerializer(suppliers.GetType(), new XmlRootAttribute("suppliers"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using (fileStream)
            {
                xml.Serialize(fileStream, suppliers, ns);
            }
        }

        private static void Ferrari(Context context)
        {
            var cars = context.Cars.Where(c => c.Make == "Ferrari")
                                   .OrderBy(m => m.Model)
                                   .ThenByDescending(td => td.TravelledDistance)
                                   .Select(f => new FerrariDto
                                   {
                                       Id = f.Id,
                                       TravelledDistance = f.TravelledDistance,
                                       Model = f.Model
                                   })
                                   .ToList();
            var fileStream = new FileStream("Ferrari.xml", FileMode.Create);
            var xml = new XmlSerializer(cars.GetType(), new XmlRootAttribute("cars"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using (fileStream)
            {
                xml.Serialize(fileStream, cars, ns);
            }
        }

        private static void Cars(Context context)
        {
            var cars = context.Cars.Where(d => d.TravelledDistance > 2000000)
                              .OrderBy(m => m.Make)
                              .ThenBy(m => m.Model)
                              .Select(c => new CarDto
                              {
                                  Make = c.Make,
                                  Model = c.Model,
                                  TravelledDistance = c.TravelledDistance
                              })
                              .ToList();

            var fileStream = new FileStream("CarsQuery.xml", FileMode.Create);
            var xml = new XmlSerializer(cars.GetType(), new XmlRootAttribute("cars"));
            var namesp = new XmlSerializerNamespaces();
            namesp.Add("", "");
            using (fileStream)
            {
                xml.Serialize(fileStream, cars,namesp);
            }
        }
    }
}