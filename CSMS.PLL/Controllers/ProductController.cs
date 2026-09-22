using CSMS.BLL.Interfaces;
using CSMS.DAL.Models;
using CSMS.PLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CSMS.PLL.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    //public async Task<IActionResult> Index()
    //{
    //    var products = await _productService.GetAllAsync();
    //    var model = products.Select(product => new ProductViewModel
    //    {
    //        Id = product.Id,
    //        Name = product.Name,
    //        Price = product.Price
    //    }).ToList();

    //    return View(model);
    //}

    public IActionResult Create()
    {
        return View(new ProductViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var product = new Product
        {
            Name = model.Name,
            Price = model.Price
        };

        await _productService.AddAsync(product);
        return RedirectToAction(nameof(Index));
    }
}
