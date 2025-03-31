using ETicaret.Core.Entities;
using ETicaret.Data.Context;
using ETicaret.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        //private readonly DatabaseContext _context;

        //public CategoriesController(DatabaseContext context)
        //{
        //    _context = context;
        //}


        private readonly IService<Category> _service;

        public CategoriesController(IService<Category> service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var category = await _service.GetQueryable().Include(p=>p.Products)//Productsı da dahil ettik idsine göre de çektik.
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}
