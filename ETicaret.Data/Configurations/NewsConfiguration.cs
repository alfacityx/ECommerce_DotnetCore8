using ETicaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ETicaret.Data.Configurations
{
    internal class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description);
            builder.Property(x => x.Image).HasMaxLength(100);
        }
    }
}
