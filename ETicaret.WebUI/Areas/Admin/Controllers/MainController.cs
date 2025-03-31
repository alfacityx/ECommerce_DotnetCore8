using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]//Main controller sadece Admin areası içerisinde çalışacak
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
