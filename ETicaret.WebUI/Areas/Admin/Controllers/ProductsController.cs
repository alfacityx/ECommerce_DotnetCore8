using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ETicaret.Core.Entities;
using ETicaret.Data.Context;
using ETicaret.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;

namespace ETicaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index(string search="")
        {
            var databaseContext = _context.Products.Where(p=>p.IsActive && p.Name.Contains(search) && p.Description.Contains(search)).Include(p => p.Brand).Include(p => p.Category);//Contains yapısını kullanarak search işlemi yapıldığında yazılanları da şartlara ekliyor.
            return View(await databaseContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description");
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                product.Image = await FileHelper.FileLoaderAsync(Image,"/Img/Products/");//Değişiklikleri product klasöründe yapacak.
                await _context.AddAsync(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile? Image, bool cbResmiSil = false)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (cbResmiSil) 
                        product.Image = string.Empty; //Eğer resmi sil butonu işaretlenmiş ise Resmi boş bir string olarak tanımlar ve resmi siler
                    if (Image is not null)//Eğer resim null değilse yani yeni resim yüklenmişse aşağıdaki işlem gerçekleşir.
                        product.Image = await FileHelper.FileLoaderAsync(Image, "/Img/Products/");//Değişiklikleri Product klasöründe yapar.
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(product.Image))
                {
                    FileHelper.FileRemover(product.Image, "/Img/News/"); //Eğer null veya boş değilse news dosyasında ki resmi sil.
                }
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
