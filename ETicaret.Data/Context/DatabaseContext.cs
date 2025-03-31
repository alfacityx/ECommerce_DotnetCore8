 using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Core.Entities;
using ETicaret.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Data.Context
{
   public  class DatabaseContext:DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Veri tabanı bağlantısı yaptığımız yer
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2KPIHU4\SQLEXPRESS;Database=ETicaretProje;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Uygulama ayağa kalktığında bir ayar varsa onları uygular
        {
            //modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            //modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Çalışan dll'in içinden classların çalıştığı yeri otamatik bulup ayarları kendisi yapacak.
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
