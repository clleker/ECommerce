using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Contexts.Main.Configuration
{
    internal class AttributeConfiguration : IEntityTypeConfiguration<Attribute_>
    {
        public void Configure(EntityTypeBuilder<Attribute_> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(255);
            builder.Property(a => a.Description).IsRequired(false).HasMaxLength(255);
        }
    }
}
