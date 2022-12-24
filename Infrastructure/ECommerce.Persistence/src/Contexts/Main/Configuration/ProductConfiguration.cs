using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Persistence.Contexts.Main.Configuration
{
    internal class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.ShortDescription).IsRequired().HasMaxLength(255);
            }
    }
}
