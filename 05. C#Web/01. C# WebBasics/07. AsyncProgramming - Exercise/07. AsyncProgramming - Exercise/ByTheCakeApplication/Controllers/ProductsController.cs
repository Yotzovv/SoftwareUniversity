﻿using System;
using System.Linq;

public class ProductsController : Controller
{
    private const string AddView = @"products\add";

    private readonly IProductService products;

    public ProductsController()
    {
        this.products = new ProductService();
    }

    public IHttpResponse Add()
    {
        this.ViewData["showResult"] = "none";

        return this.FileViewResponse(AddView);
    }

    public IHttpResponse Add(AddProductViewModel model)
    {
        if(model.Name.Length < 3
        || model.Name.Length > 30
        || model.ImageUrl.Length < 3
        || model.ImageUrl.Length > 2000)
        {
            this.AddError("Product information is not valid");

            return this.FileViewResponse(AddView);
        }

        this.products.Create(model.Name, model.Price, model.ImageUrl);

        this.ViewData["name"] = model.Name;
        this.ViewData["price"] = model.Price.ToString();
        this.ViewData["imageUrl"] = model.ImageUrl;
        this.ViewData["showResult"] = "blok";

        return this.FileViewResponse(AddView);
    }

    public IHttpResponse Search(IHttpRequest req)
    {
        const string searchTermKey = "searchTerm";

        var urlParameters = req.UrlParameters;

        this.ViewData["result"] = string.Empty;

        var searchTerm = urlParameters.ContainsKey(searchTermKey)
                       ? urlParameters[searchTermKey]
                       : null;

        this.ViewData["searchTerm"] = searchTerm;

        var result = this.products.All(searchTerm);

        if(!result.Any())
        {
            this.ViewData["result"] = "No cakes found";
        }
        else
        {
            var allProducts = result.Select(c =>
            $@"<div><a href=""/cakes/{c.Id}"">{c.Name}</a> - ${c.Price:F2} <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a></div>");

            var allProductsAsString = string.Join(Environment.NewLine, allProducts);

            this.ViewData["result"] = allProductsAsString;
        }

        this.ViewData["showCart"] = "none";

        var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

        if(shoppingCart.ProductIds.Any())
        {
            var totalProducts = shoppingCart.ProductIds.Count;
            var totalProductsText = totalProducts != 1 ? "products" : "product";

            this.ViewData["showCart"] = "block";
            this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
        }

        return this.FileViewResponse(@"products\search");
    }

    public IHttpResponse Details(int id)
    {
        var product = this.products.Find(id);

        if(product == null)
        {
            return new NotFoundResponse();
        }

        this.ViewData["name"] = product.Name;
        this.ViewData["price"] = product.Price.ToString("f2");
        this.ViewData["imageUrl"] = product.ImageUrl;

        return this.FileViewResponse(@"products\details");
    }
}
