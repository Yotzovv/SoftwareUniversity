using CarDealer.Services;
using CarDealer.Web.Models.Parts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarDealer.Web.Controllers
{
    public class PartsController : Controller
    {
        private const int PageSize = 25;

        private readonly IPartService parts;
        private readonly ISupplierService suppliers;

        public PartsController(IPartService parts, ISupplierService suppliers)
        {
            this.parts = parts;
            this.suppliers = suppliers;
        }


        public IActionResult Edit(int id)
        {
            var part = this.parts.ById(id);

            if(part == null)
            {
                return NotFound();
            }

            return View(new PartFormModel
            {
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity,
                IsEdit = true,
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, PartFormModel model)
        {
            if(!ModelState.IsValid)
            {
                model.IsEdit = true;
                return this.View(model); 
            }

            this.parts.Edit(
                id,
                model.Price,
                model.Quantity);

            return RedirectToAction(nameof(All));
        }


        public IActionResult Delete(int id) => this.View(id);
        
        public IActionResult Destroy(int id)
        {
            this.parts.Delete(id);

            return RedirectToAction(nameof(All));
        }


        public IActionResult All(int page = 1)
        {
            return View(new PartPageListingModel
            {
                Parts = this.parts.All(page, PageSize),
                CurrentPage = page,
                TotalPages = (int) Math.Ceiling(this.parts.Total() / (double)PageSize),
            });
        }


        public IActionResult Create() 
            => View(new PartFormModel
               {
                   Suppliers = this.GetSupplierListItems(),
               });

        [HttpPost]
        public IActionResult Create(PartFormModel model)
        {
            if(!ModelState.IsValid)
            {
                model.Suppliers =  this.GetSupplierListItems();
                return this.View(model);
            }

            this.parts.Create(
                model.Name,
                model.Price,
                model.Quantity,
                model.SupplierId);

            return this.RedirectToAction(nameof(All));
        }


        private IEnumerable<SelectListItem> GetSupplierListItems()
                => this.suppliers
                       .All()
                       .Select(s => new SelectListItem
                       {
                           Text = s.Name,
                           Value = s.Id.ToString()
                       });
    }
}
