using Castle.Core.Configuration;
using ECommerce.Core.Domain.AppUser;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.Persistence.Contexts.Main
{
    public class MainDbContext: DbContext
    {

        // Add-Migration -Name V? -OutputDir src\Contexts\Main\Migrations -Context ECommerce.Persistence.Contexts.Main.MainDbContext -Project ECommerce.Persistence -StartupProject ECommerce.AdminAPI

        // Update-Database -Context ECommerce.Persistence.Contexts.Main.MainDbContext -Project ECommerce.Persistence -StartupProject ECommerce.AdminAPI

        // Remove-Migration -Context ECommerce.Persistence.Contexts.Main.MainDbContext -Project ECommerce.Persistence -StartupProject ECommerce.AdminAPI

        public MainDbContext(DbContextOptions options)
        : base(options)
        {
        }
       
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSetting> CustomerSettings { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AuthGroup> AuthGroups { get; set; }
        public DbSet<AuthGroupRole> AuthGroupRoles { get; set; }
        public DbSet<UserAuthGroup> UserAuthGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Attribute_> Attributes { get; set; }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductCard> ProductCards { get; set; }
        public DbSet<ProductCardPrice> ProductCardPrices { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCardAttribute> ProductCardAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
