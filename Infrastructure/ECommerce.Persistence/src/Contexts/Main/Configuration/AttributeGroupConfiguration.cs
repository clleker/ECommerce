

using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Contexts.Main.Configuration
{
    internal class AttributeGroupConfiguration : IEntityTypeConfiguration<AttributeGroup>
    {
        public void Configure(EntityTypeBuilder<AttributeGroup> builder)
        {
            builder.Property(ag => ag.Id).IsRequired();
            builder.Property(ag => ag.Title).IsRequired().HasMaxLength(255);
        }
    }
}
