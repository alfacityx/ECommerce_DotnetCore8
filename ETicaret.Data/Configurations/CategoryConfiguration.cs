using ETicaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ETicaret.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Image).HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.HasData(
                new Category
                {
                    Name = "Elektronik",
                    Description ="Elektrik-Elektronik Kategorisi",
                    Id=1,
                    IsActive = true,
                    IsTopMenu = true,
                    ParentId = 0,
                    OrderNo = 1,
                },
                new Category
                {
                    Name = "Bilgisayar",
                    Description = "Bilgisayar Kategorisi",
                    Id = 2,
                    IsActive = true,
                    IsTopMenu = true,
                    ParentId = 0,
                    OrderNo = 2,
                });
        }
    }
}
