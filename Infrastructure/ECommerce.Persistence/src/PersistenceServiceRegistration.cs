using ECommerce.Core.Domain.AppUser;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts.Main;
using ECommerce.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration, ServiceLifetime contextLifetime = ServiceLifetime.Scoped)
        {
            var connectionString = configuration["Data:MainDbContext:ConnectionString"];

            #region DataBase Connecttion Config
            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging();
                
            }, ServiceLifetime.Scoped);

            #endregion


            services.AddScoped<IRepository<Product>, Repository<Product,MainDbContext>>();
            services.AddScoped<IRepository<Attribute_>, Repository<Attribute_, MainDbContext>>();
            services.AddScoped<IRepository<AttributeGroup>, Repository<AttributeGroup, MainDbContext>>();
            services.AddScoped<IRepository<Category>, Repository<Category, MainDbContext>>();
            services.AddScoped<IRepository<AppUser>, Repository<AppUser, MainDbContext>>();
            services.AddScoped<IRepository<Customer>, Repository<Customer, MainDbContext>>();
            services.AddScoped<IRepository<AuthGroupRole>, Repository<AuthGroupRole, MainDbContext>>();
            services.AddScoped<IRepository<AuthGroup>, Repository<AuthGroup, MainDbContext>>();
            services.AddScoped<IRepository<ProductCard>, Repository<ProductCard, MainDbContext>>();
            services.AddScoped<IRepository<ProductCardAttribute>, Repository<ProductCardAttribute, MainDbContext>>();
            services.AddScoped<IRepository<Picture>, Repository<Picture, MainDbContext>>();
            services.AddScoped<IRepository<ProductCardPicture>, Repository<ProductCardPicture, MainDbContext>>();
            services.AddScoped<IRepository<AppRole>, Repository<AppRole, MainDbContext>>();


            //services.AddRelationData<MainDbContext>(
            //        options =>
            //        {
            //            options.ConfigureDatabase(connectionString, configuration["Data:MainDbContext:MigrationsAssembly"]);
            //            options.EnableSensitiveDataLogging();
            //        },
            //        contextLifetime);

            return services;
        }
    }
}
