using ETicaret.Core.Entities;
using ETicaret.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy ="AdminPolicy")]
    public class AppUsersController : Controller
    {
       
            private readonly DatabaseContext _context;


            public AppUsersController(DatabaseContext context)
            {
                _context = context;
            }

            // GET: Admin/Users
            public async Task<IActionResult> Index()
            {
                return View(await _context.AppUsers.ToListAsync());
            }

            // GET: Admin/Users/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.AppUsers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }

            // GET: Admin/Users/Create
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(AppUser user)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }

            // GET: Admin/Users/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.AppUsers.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, AppUser user)
            {
                if (id != user.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserExists(user.Id))
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
                return View(user);
            }

            // GET: Admin/Users/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.AppUsers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }

            // POST: Admin/Users/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var user = await _context.AppUsers.FindAsync(id);
                _context.AppUsers.Remove(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool UserExists(int id)
            {
                return _context.AppUsers.Any(e => e.Id == id);
            }
        }
    }

