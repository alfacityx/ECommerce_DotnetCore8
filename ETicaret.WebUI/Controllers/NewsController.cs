using ETicaret.Core.Entities;
using ETicaret.Data.Context;
using ETicaret.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.Controllers
{
    public class NewsController : Controller
    {
        private readonly IService<News> _service;

        public NewsController(IService<News> service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound("Geçersiz İstek!");
            }

            var news = await _service.GetAsync(m => m.Id == id && m.IsActive);
            if (news == null)
            {
                return NotFound("Aradığınız Kampanya Bulunamadı!");
            }

            return View(news);
        }
    }
}
