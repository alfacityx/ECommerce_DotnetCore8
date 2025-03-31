using ETicaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ETicaret.Data.Configurations
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Image).HasMaxLength(100);
            builder.Property(x => x.Link).HasMaxLength(100);

        }
    }
}
