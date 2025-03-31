using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ETicaret.Core.Entities;
using ETicaret.Data.Context;
using Microsoft.AspNetCore.Authorization;

namespace ETicaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class AdressesController : Controller
    {
        private readonly DatabaseContext _context;

        public AdressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Adresses
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Adresses.Include(a => a.appUser);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Admin/Adresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adresses
                .Include(a => a.appUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // GET: Admin/Adresses/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Email");
            return View();
        }

        // POST: Admin/Adresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Adress adress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Email", adress.AppUserId);
            return View(adress);
        }

        // GET: Admin/Adresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adresses.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Email", adress.AppUserId);
            return View(adress);
        }

        // POST: Admin/Adresses/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Adress adress)
        {
            if (id != adress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdressExists(adress.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Email", adress.AppUserId);
            return View(adress);
        }

        // GET: Admin/Adresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adresses
                .Include(a => a.appUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // POST: Admin/Adresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adress = await _context.Adresses.FindAsync(id);
            if (adress != null)
            {
                _context.Adresses.Remove(adress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdressExists(int id)
        {
            return _context.Adresses.Any(e => e.Id == id);
        }
    }
}
