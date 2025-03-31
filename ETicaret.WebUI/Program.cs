 using System.Security.Claims;
using ETicaret.Data.Context;
using ETicaret.Service.Abstract;
using ETicaret.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".ETicaret.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout=TimeSpan.FromDays(1);
    options.IOTimeout=TimeSpan.FromMinutes(10);
});//Session yapýsý favorileri listelemek için
builder.Services.AddDbContext<DatabaseContext>();//DatabaseContext hatasý varsa bunu ekle
builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Account/SignIn";//Kullanýcý giriþ için
    x.AccessDeniedPath = "/AccessDenied";//Kullanýcýnýn Eriþimi dýþýnda ki yerleri engellemek için
    x.Cookie.Name = "Account";
    x.Cookie.MaxAge=TimeSpan.FromDays(1);//Hesabýn ne kadar açýk kalabileceðini gösterir.
    x.Cookie.IsEssential = true;//Kalýcý cookie oluþturma
});
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role,"Admin"));//AdminPolicynin kullanýldýðý yerlere sadece adminler girebilir
    x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin","User","Customer"));//UserPolicynin kullanýldýðý yerlere rolleri tanýmlý olanlar girebilir.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession(); //Session kullanacaðýmýzý belirttik

app.UseAuthentication();//Önce oturum açma
app.UseAuthorization();//Sonra yetkilendirme
app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Home",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
