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
                 options.UseSqlServer(connectionString));

            #endregion


            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Attribute_>, Repository<Attribute_>>();
            services.AddScoped<IRepository<AttributeGroup>, Repository<AttributeGroup>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<IRepository<AuthGroupRole>, Repository<AuthGroupRole>>();
            services.AddScoped<IRepository<AuthGroup>, Repository<AuthGroup>>();


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
