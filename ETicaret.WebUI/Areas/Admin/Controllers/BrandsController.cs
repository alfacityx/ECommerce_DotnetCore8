using ETicaret.Core.Entities;
using ETicaret.Data.Context;
using ETicaret.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Policy = "AdminPolicy")]
    
    public class BrandsController : Controller
    {
        private readonly DatabaseContext _context;


        public BrandsController(DatabaseContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync());
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand,IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {
                brand.Logo=await FileHelper.FileLoaderAsync(Logo);
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Brand brand, IFormFile? Logo,bool cbResmiSil=false)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (cbResmiSil)
                        brand.Logo = string.Empty;
                    if (Logo is not null)
                        brand.Logo = await FileHelper.FileLoaderAsync(Logo);
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Id))
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
            return View(brand);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
          if (brand != null)
            {
                if (!string.IsNullOrEmpty(brand.Logo))
                {
                    FileHelper.FileRemover(brand.Logo);
                }
                _context.Brands.Remove(brand);
            }
           
            
            
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }
       
    }
}
