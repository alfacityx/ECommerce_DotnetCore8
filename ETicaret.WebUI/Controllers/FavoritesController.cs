using ETicaret.Core.Entities;
using ETicaret.Service.Abstract;
using ETicaret.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IService<Product> _service;

        public FavoritesController(IService<Product> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var favoriler = GetFavorites();//metodunu çağırarak favori ürünleri alır ve favoriler değişkenine atar.
            return View(favoriler);
        }
        private List<Product> GetFavorites()
        {
            return HttpContext.Session.GetJson<List<Product>>("GetFavorites") ?? []; //): Oturumdan "GetFavorites" anahtarı ile saklanan favori ürünleri JSON formatında alır ve List<Product> türünde bir nesneye dönüştürür.
            //Eğer oturumda "GetFavorites" anahtarı ile saklanan veri yoksa(null ise), boş bir List<Product> döner.
        }
        public IActionResult Add(int ProductId)
        {
            var favoriler = GetFavorites();//metodunu çağırarak favori ürünleri alır ve favoriler değişkenine atar.
            var product = _service.Find(ProductId);
            if (product != null && !favoriler.Any(p=>p.Id==ProductId))
            {
                favoriler.Add(product);
                HttpContext.Session.SetJson("GetFavorites",favoriler);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int ProductId)
        {
            var favoriler = GetFavorites();//metodunu çağırarak favori ürünleri alır ve favoriler değişkenine atar.
            var product = _service.Find(ProductId);
            if (product != null && favoriler.Any(p => p.Id == ProductId))
            {
                favoriler.RemoveAll(p=>p.Id==product.Id);
                HttpContext.Session.SetJson("GetFavorites", favoriler);
            }
            return RedirectToAction("Index");
        }
    }
}
