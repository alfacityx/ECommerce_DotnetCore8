using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETicaret.Data.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Phone).HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(x => x.Password).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(x => x.UserName).HasColumnType("varchar(50)").HasMaxLength(50);
            //Başlangıç kullanıcısını oluşturmak için yapıldı.
            builder.HasData(
                new AppUser {
                    Id=1,                   
                    UserName = "Admin",
                    Email="admin123@gmail.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name="admin",
                    Password="admin",
                    Surname="admin",

                    
                    
                });
        }
    }
}
