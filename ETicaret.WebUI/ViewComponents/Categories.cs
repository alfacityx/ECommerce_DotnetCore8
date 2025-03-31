using ETicaret.Core.Entities;
using ETicaret.Data.Context;
using ETicaret.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.ViewComponents
{
    public class Categories: ViewComponent
    {
        private readonly IService<Category> _service;

        public Categories(IService<Category> service)
        {
            _service = service;
        }
        //Burada asekron olarak kategorileri veritabanından çektik.
        public async Task<IViewComponentResult>InvokeAsync()
        {
            return View(await _service.GetAllAsync(c=>c.IsActive && c.IsTopMenu));
        }
    }
}
