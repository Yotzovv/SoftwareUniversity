using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ImportData(context);
            //Queries(context);
        }

        private static void Queries(Context context)
        {
            //OrderedCustomers(context);
            //ToyotaCars(context);    
            //LocalSuppliers(context);
            //Cars(context);
            //TotalSalesByCustomer(context);
            //SalesWithDiscount(context);
        }

        private static void SalesWithDiscount(Context context)
        {
            var sales = context.Sales.Select(c => new
            {
                car = new
                {
                    Make = c.Car.Make,
                    Model = c.Car.Model,
                    TravelledDistance = c.Car.TravelledDistance,
                },
                customer = new
                {
                    customerName = c.Customer.Name,
                    Discount = c.Discount,
                    Price = c.Car.Parts.Sum(p => p.Price),
                    priceWithDiscount = c.Car.Parts.Sum(p => p.Price) - ((c.Discount*c.Car.Parts.Sum(p => p.Price))/100),
                }
            });
            string json = JsonConvert.SerializeObject(sales, Formatting.Indented,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });
            File.WriteAllText("../../salesDiscount.json", json);
        }

        private static void TotalSalesByCustomer(Context context)
        {
            var customers = context.Customers
                                   .Where(c => c.Sales.Count > 0)
                                   .Select(x => new
                                   {
                                       fullName = x.Name,
                                       BoughtCars = x.Sales.Count,
                                       spentMoney = x.Sales.Sum(f => f.Car.Parts.Sum(w => w.Price)),
                                   })
                                   .OrderByDescending(s => s.spentMoney)
                                   .ThenByDescending(o => o.BoughtCars);

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });
            File.WriteAllText("../../salesByCustomer.json", json);
        }

        private static void Cars(Context context)
        {
            var cars = context.Cars.Select(x => new
            {
                Make = x.Make,
                Model = x.Model,
                TravelledDistance = x.TravelledDistance,
                Parts = x.Parts.Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                })
            });
            string json = JsonConvert.SerializeObject(cars, Formatting.Indented,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });
            File.WriteAllText("../../cars&parts.json", json);
        }

        private static void LocalSuppliers(Context context)
        {
            var suppliers = context.Suppliers.Where(p => p.IsImporter == false).Select(x => new {Id = x.Id, Name = x.Name, PartsCount = x.Parts.Count });
            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });
            File.WriteAllText("../../suppliers0.json", json);
        }

        private static void ToyotaCars(Context context)
        {
            var toyotas = context.Cars
                                .Where(m => m.Make == "Toyota")
                                .OrderBy(m => m.Model)
                                .ThenByDescending(d => d.TravelledDistance)
                                .Select(c => new
                                {
                                    Id = c.Id,
                                    Make = c.Make,
                                    Model = c.Model,
                                    TravelledDistance = c.TravelledDistance,
                                });
            string json = JsonConvert.SerializeObject(toyotas, Formatting.Indented,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });
            File.WriteAllText("../../toyotas.json", json);
        }

        private static void OrderedCustomers(Context context)
        {
            var customersJsOn = context.Customers
                                      .OrderBy(d => d.DateOfBirth)
                                      .ThenBy(yd => yd.IsYoungDriver)
                                      .Select(c => new
                                      {
                                          Id = c.Id,
                                          Name = c.Name,
                                          BirthDate = c.DateOfBirth,
                                          IsYoungDriver = c.IsYoungDriver,
                                          Sales = c.Sales.Select(s => new
                                          {
                                              CarId = s.Car_Id,
                                              CustomerId = s.Customer_Id
                                          })
                                      });
            string json = JsonConvert.SerializeObject(customersJsOn, Formatting.Indented,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });
            File.WriteAllText("../../orderedCustomers.json", json);
        }

///---------------------------------------------------------------\\\

        private static void ImportData(Context context)
        {
            ImportSuppliers(context);
            ImportParts(context);
            ImportCars(context);
            ImportCustomers(context);
            ImportSales(context);
        }

        private static void ImportSuppliers(Context context)
        {
            string json = File.ReadAllText("../../Import/suppliers.json");
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(json);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }

        private static void ImportParts(Context context)
        {
            string json = File.ReadAllText("../../Import/parts.json");
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(json);
            Random random = new Random();
            foreach (var part in parts)
            {
                int supplierId = 0;
                int count = context.Suppliers.Count();
                supplierId = random.Next(1, count);
                part.Supplier_Id = supplierId;
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();

        }

        private static void ImportCars(Context context)
        {
            string json = File.ReadAllText("../../Import/cars.json");
            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(json);
            Random random = new Random();

            foreach (var car in cars)
            {
                int count = random.Next(11, 20);
                
                for (int i = 0; i < count; i++)
                {
                    int part = random.Next(1, 131);
                    car.Parts.Add(context.Parts.Find(part));
                }
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void ImportCustomers(Context context)
        {
            string json = File.ReadAllText("../../Import/customers.json");
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void ImportSales(Context context)
        {
            int[] discounts = new int[] { 5, 10, 5, 20, 30, 40, 50 };
            int carsCount = context.Cars.Count();
            int customersCount = context.Customers.Count();
            int discountsCount = discounts.Count();

            List<Sale> sales = new List<Sale>();
            Random random = new Random();

            for (int i = 0; i < 21; i++)
            {
                Sale sale = new Sale()
                {
                    Car = context.Cars.Find(random.Next(1, carsCount)),
                    Customer = context.Customers.Find(random.Next(1, customersCount)),
                    Discount = discounts[(random.Next(0, discountsCount))],
                };
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();
        }
    }
}
