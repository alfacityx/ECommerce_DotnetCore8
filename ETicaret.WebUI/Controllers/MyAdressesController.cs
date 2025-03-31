using System.Threading.Tasks;
using ETicaret.Core.Entities;
using ETicaret.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.Controllers
{
    [Authorize]
    public class MyAdressesController : Controller
    {
        private readonly IService<AppUser> _appuserservice;
        private readonly IService<Adress> _adressservice;

        public MyAdressesController(IService<AppUser> service, IService<Adress> adressservice)
        {
            _appuserservice = service;
            _adressservice = adressservice;
        }
        public async Task<IActionResult> Index()
        {
            var appUser = await _appuserservice.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Bilgisi Bulunamadı! Oturumunuzu Kapatıp Tekrar Giriş Yapınız.");
            }
            var model = await _adressservice.GetAllAsync(u => u.appUser.Id == appUser.Id);
            return View(model);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Adress adress)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var appUser = await _appuserservice.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
                    if (appUser != null)
                    {
                        adress.AppUserId = appUser.Id;
                        _adressservice.Add(adress);
                        await _adressservice.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));

                    }
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Hata Oluştu");
                }

            }
            ModelState.AddModelError("", "Kayıt Başarısız!");
            return View(adress);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var appUser = await _appuserservice.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Bilgisi Bulunamadı! Oturumunuzu Kapatıp Tekrar Giriş Yapınız.");
            }
            var model = await _adressservice.GetAsync(u => u.AdressGuid.ToString() == id && u.AppUserId == appUser.Id);
            if (model == null)
            {
                return NotFound("Adres Bilgisi Bulunamadı!");
            }


            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Adress adress)
        {
            var appUser = await _appuserservice.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Bilgisi Bulunamadı! Oturumunuzu Kapatıp Tekrar Giriş Yapınız.");
            }
            var model = await _adressservice.GetAsync(u => u.AdressGuid.ToString() == id && u.AppUserId == appUser.Id);
            if (model == null)

                return NotFound("Adres Bilgisi Bulunamadı!");
            model.Title = adress.Title;
            model.District = adress.District;
            model.City = adress.City;
            model.OpenAdress = adress.OpenAdress;
            model.IsDeliveryAdress = adress.IsDeliveryAdress;
            model.IsBillingAdress = adress.IsBillingAdress;
            model.IsActive = adress.IsActive;
            var otheraAdresses = await _adressservice.GetAllAsync(x => x.AppUserId == appUser.Id && x.Id != model.Id);
            foreach (var item in otheraAdresses)
            {
                item.IsDeliveryAdress = false; //Bir kullanıcının 1 tane teslimat adresi ve iş adresi olabilir
                item.IsBillingAdress = false;
                _adressservice.Update(item);
            }
            try
            {
                _adressservice.Update(model);
                await _adressservice.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Hata Oluştu");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var appUser = await _appuserservice.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Bilgisi Bulunamadı! Oturumunuzu Kapatıp Tekrar Giriş Yapınız.");
            }
            var model = await _adressservice.GetAsync(u => u.AdressGuid.ToString() == id && u.AppUserId == appUser.Id);
            if (model == null)
            {
                return NotFound("Adres Bilgisi Bulunamadı!");
            }


            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, Adress adress)
        {
            var appUser = await _appuserservice.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Bilgisi Bulunamadı! Oturumunuzu Kapatıp Tekrar Giriş Yapınız.");
            }
            var model = await _adressservice.GetAsync(u => u.AdressGuid.ToString() == id && u.AppUserId == appUser.Id);
            if (model == null)
                return NotFound("Adres Bilgisi Bulunamadı!");
            try
            {
                _adressservice.Delete(model);
                await _adressservice.SaveChangesAsync();
               return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
                ModelState.AddModelError("","Hata Oluştu");

            }
            return View(model);
        }
    }
}
