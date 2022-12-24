using ECommerce.Application.Services.Storage;
using ECommerce.Core.Infrastructure.MessageBrokers;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Adapters.StorageService.Azure;
using ETicaretAPI.Infrastructure.Adapters.MailQueneService;
using ETicaretAPI.Infrastructure.Services.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
           IConfiguration configuration, ServiceLifetime contextLifetime = ServiceLifetime.Scoped)
        {
            services.AddStorage<BlobAdapter>();
            services.AddScoped<IMessageBrokerHelper, MqQueueAdapter>();

            //serviceCollection.AddScoped<IMailService, MailService>();
            //serviceCollection.AddScoped<IApplicationService, ApplicationService>();


            return services;
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
