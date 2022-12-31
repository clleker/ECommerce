using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Contexts.Main.Configuration
{
    internal class ProductCardAttributeConfiguration : IEntityTypeConfiguration<ProductCardAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductCardAttribute> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id).IsRequired();
        }
    }
}
