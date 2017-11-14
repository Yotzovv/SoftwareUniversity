using CarDealer.Services;
using CarDealer.Services.Models;
using CarDealer.Web.Infrastructure.Extensions;
using CarDealer.Web.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

    //   [Route(nameof(Edit) + "/{id}")]
    //   public IActionResult Edit(int id)
    //   {
    //       var customer = this.customers.ById(id);
    //
    //       if(customer == null)
    //       {
    //           return NotFound();
    //       }
    //
    //       return View(new CustomerFormModel
    //       {
    //           Name = customer.Name,
    //           BirthDay = customer.BirthDay,
    //           IsYoungDriver = customer.IsYoungDriver
    //       });
    //   }


        [Route(nameof(Create))]
        public IActionResult Create() => this.View();

    // [HttpPost]
    // [Route(nameof(Create))]
    // public IActionResult Create(CustomerFormModel model)
    // {
    //     if(!ModelState.IsValid)
    //     {
    //         return this.View(model);
    //     }
    //
    //     this.customers.Create(
    //         model.Name,
    //         model.BirthDay,
    //         model.IsYoungDriver);
    //
    //     return RedirectToAction(nameof(All), new { order = OrderDirection.Ascending });
    // }


        [Route("customers/all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirection = order.ToLower() == "ascending" ?
                                                    OrderDirection.Ascending
                                                : OrderDirection.Descendin;

            var customers = this.customers.OrderedCusotmers(orderDirection);

            return View(new AllCustomersModel
            {
                Customers = customers,
                OrderDirection = orderDirection
            });
        }

        [Route("customers/{id}")]
        public IActionResult Details(int id)
        {
            return this.ViewOrNotFound(this.customers.TotalSalesById(id));
        }
    }
}
