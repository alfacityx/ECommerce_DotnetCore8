using ETicaret.Core.Entities;
using ETicaret.Data.Context;
using ETicaret.Service.Abstract;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IService<Product> _service;

        public ProductsController(IService<Product> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index( string q="")
        {
            var databaseContext = _service.GetAllAsync(p => p.IsActive && p.Name.Contains(q) || p.Description.Contains(q));
            return View(await databaseContext);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _service.GetQueryable()
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductDetailViewModel()
            {
                Product= product,
                RelatedProducts = _service.GetQueryable().Where(p=>p.IsActive && p.CategoryId == product.CategoryId && p.Id!=product.Id)
            };

            return View(model);
        }
    }
}
