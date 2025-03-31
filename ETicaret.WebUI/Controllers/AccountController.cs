using System.Net.Mail;
using System.Security.Claims; //Login Giriş Hak kütüphanesi
using ETicaret.Core.Entities;
using ETicaret.Service.Abstract;
using ETicaret.WebUI.Models;
using ETicaret.WebUI.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.Controllers
{
    public class AccountController : Controller
    {

        //private readonly DatabaseContext _context;


        //public AccountController(DatabaseContext context)
        //{
        //    _context = context;
        //}

        private readonly IService<AppUser> _service;
        private readonly IService<Order> _orderservice;

        public AccountController(IService<AppUser> service, IService<Order> orderservice)
        {
            _service = service;
            _orderservice = orderservice;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            AppUser appUser = await _service.GetAsync(p => p.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound();
            }
            var model = new UserEditViewModel()
            {
                Id = appUser.Id,
                Name = appUser.Name,
                Surname = appUser.Surname,
                Email = appUser.Email,
                Password = appUser.Password,
                Phone = appUser.Phone

            };
            return View(model);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser appUser = await _service.GetAsync(p => p.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
                    if (appUser is not null)
                    {
                        appUser.Name = model.Name;
                        appUser.Surname = model.Surname;
                        appUser.Email = model.Email;
                        appUser.Password = model.Password;
                        _service.Update(appUser);
                        var sonuc = _service.SaveChanges();
                        if (sonuc > 0)
                        {
                            TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                    <strong>Bilgileriniz Başarıyla Güncellendi.</strong>
                    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
                    </div>";
                            return RedirectToAction("Index");
                        }

                    }

                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Bir Hata Oluştu");
                }
            }

            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            AppUser appUser = await _service.GetAsync(p => p.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("SignIn");
            }
            var model = _orderservice.GetQueryable().Where(x => x.AppUserId == appUser.Id).Include(z => z.OrderLines).ThenInclude(c => c.Product); //Userıd orderline ve producttaki bilgileri dahil et siparişlerim kısmına
            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = await _service.GetAsync(x => x.Email == loginViewModel.Email & x.Password == loginViewModel.Password & x.IsActive);
                    if (account == null)
                    {
                        ModelState.AddModelError("", "Giriş Başarısız!");
                    }
                    else
                    {
                        var claims = new List<Claim>(){
                            new(ClaimTypes.Name,account.Name),
                            new(ClaimTypes.Role,account.IsAdmin ? "Admin" : "Customer"),
                             new(ClaimTypes.Email,account.Email),
                             new("UserId",account.Id.ToString()),
                             new("UserGuid",account.UserGuid.ToString()),
                        };
                        var userIdentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(userPrincipal);
                        return Redirect(string.IsNullOrEmpty(loginViewModel.ReturnUrl) ? "/" : loginViewModel.ReturnUrl); //Eğer loginViewModel de geri dönmek istediğin url varsa dön yoksa home yolla
                    }

                }
                catch (Exception hata)
                {
                    //Loglama
                    ModelState.AddModelError("", "Hatalı Giriş Yaptınız!");
                }
            }
            return View(loginViewModel);
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AppUser user)
        {
            user.IsAdmin = false;
            user.IsActive = true;
            if (ModelState.IsValid)
            {
                await _service.AddAsync(user);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("SignIn");
        }
        [HttpGet]
        public IActionResult PasswordRenew()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordRenew(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                ModelState.AddModelError("", "Email Boş Geçilemez");
                return View();

            }
            AppUser appUser = await _service.GetAsync(p => p.Email == Email);
            if (appUser == null)
            {
                ModelState.AddModelError("", "Böyle Bir Email Bulunamadı!");
                return View();

            }
            string mesaj = $"Merhaba,\r\n\r\nŞifre yenileme talebini aldık. \"Şifremi Güncelle\" butonuna tıklayarak yeni şifreni belirleyebilirsin." +
                $" <a href='https://localhost:7160/Account/PasswordChange?user={appUser.UserGuid.ToString()}' class=\'btn btn-danger w-100 py-2 mt-2\'>Şifremi Güncelle</a>";
            var sonuc = await MailHelper.SendMailAsync(Email, "Shopiverse.com| Şifremi Unuttum 🔑", mesaj);
            if (sonuc)
            {
                TempData["Message"] = $@"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                    <strong> {appUser.Email} adresine şifre yenileme linkiniz gönderildi.</strong>
                    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
                    </div>";
            }
            else
            {
                TempData["Message"] = $@"<div class=""alert alert-danger alert-dismissible fade show"" role=""alert"">
                    <strong> {appUser.Email} adresine şifre yenileme linki gönderilemedi.</strong>
                    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
                    </div>";

            }
            return View();
        }
        public async Task<IActionResult> PasswordChange(string user)
        {
            if (user == null)
            {
                return BadRequest("Geçersiz İstek!");
            }
            AppUser appUser = await _service.GetAsync(p => p.UserGuid.ToString() == user);
            if (appUser == null)
            {
                return NotFound("Geçersiz Değer!");
            }


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordChange(string user,string Password)
        {
            if (user == null)
            {
                return BadRequest("Geçersiz İstek!");
            }
            AppUser appUser = await _service.GetAsync(p => p.UserGuid.ToString() == user);
            if (appUser == null)
            {
                ModelState.AddModelError("", "Geçersiz Değer");
                return View();
            }
            appUser.Password = Password;
            var sonuc= await _service.SaveChangesAsync();
            if (sonuc > 0 )
            {
                TempData["Message"] = $@"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                    <strong>Şifreniz Başarıyla Güncellendi.Tekrar Oturum Açabilirsiniz.</strong>
                    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
                    </div>";
            }
            else
            {
                ModelState.AddModelError("", "Güncelleme Başarısız!");
            }


                return View();
        }
    }
}
