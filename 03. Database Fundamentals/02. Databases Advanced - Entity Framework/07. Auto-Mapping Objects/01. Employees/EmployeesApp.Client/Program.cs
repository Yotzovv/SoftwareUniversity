using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeesApp.Data;
using EmployeesApp.Models;
using EmployeesApp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureAutoMapping();
            //InititializeDataBase();
            using (EmployeesContext context = new EmployeesContext())
            {
                var employees = context.Employees
                                                  .Where(a => a.Birthday.Value.Year < 1990)
                                                  .OrderByDescending(d => d.Salary)
                                                  .ProjectTo<EmployeeDto>();
                foreach (EmployeeDto employee in employees)
                {
                    Console.WriteLine(employee.ToString());
                }
            };


            //IEnumerable<Employee> managers = CreateManagers();
            //IEnumerable<ManagerDto> managerDtos = Mapper.Map<IEnumerable<Employee>,
            //    IEnumerable<ManagerDto>>(managers);

            //foreach (ManagerDto managerDto in managerDtos)
            //{
            //    Console.WriteLine(managerDto.ToString());
            //}

            ////// ex.I
            //Employee emp = new Employee()
            //{
            //    FirstName = "Ivan",
            //    LastName = "Petkanov",
            //    Salary = 50000M,
            //    Birthday = DateTime.Now,
            //    Address = "eeokf"
            //};
            //EmployeeDto dto = Mapper.Map<EmployeeDto>(emp);
            //Console.WriteLine($"{dto.FirstName} - {dto.LastName} - {dto.Salary}");
        }

        private static void SeedDataBase(IEnumerable<Employee> employees)
        {
            using (EmployeesContext context = new EmployeesContext())
            {
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
                
        }

        private static void InititializeDataBase()
        {
            using (EmployeesContext context = new EmployeesContext())
            {
                context.Database.Initialize(true);
            }
        }



        private static void ConfigureAutoMapping()
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<Employee, EmployeeDto>()
                      .ForMember(e => e.ManagerLastName, configExpression =>
                                 configExpression.MapFrom(e => e.Manager.LastName));
                action.CreateMap<Employee, ManagerDto>()
                      .ForMember(dto => dto.EmployeesCount, configExpression => 
                      configExpression.MapFrom(e => e.Employees.Count));
            });
        }

        private static IEnumerable<Employee> CreateEmployees()
        {
            var managers = new List<Employee>();

                var manager = new Employee()
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    Address = "Sofia tintqva 18",
                    Birthday = new DateTime(1989, 2, 5),
                    Employees = new List<Employee>(),
                    IsOnHoliday = false,
                    Manager = new Employee() { FirstName = "Petkan", LastName = "Dragan" },
                    Salary = 10000M,
                };

                var employee1 = new Employee()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Salary = 1204M,
                    Manager = manager,
                    Birthday = new DateTime(1989, 2 ,3)
                };

                var employee2 = new Employee()
                {
                    FirstName = "Stephen",
                    LastName = "Asenov",
                    Salary = 1234M,
                    Manager = manager,
                };

                var employee3 = new Employee()
                {
                    FirstName = "Koko",
                    LastName = "Shanel",
                    Salary = 1234M,
                    Manager = manager,
                };

                manager.Employees.Add(employee1);
                manager.Employees.Add(employee2);
                manager.Employees.Add(employee3);
                managers.Add(manager);
            return managers;
        }
    }
}
