

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Application.Abstracts.UserAuth.JwtToken;
using ECommerce.Application.Abstracts.CustomerAuth.JwtToken;

namespace ECommerce.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(),ServiceLifetime.Transient);
            services.AddScoped<ITokenUserHelper, JwtUserHelper>();
            services.AddScoped<ITokenCustomerHelper, JwtCustomerHelper>();


            // All service classes using the 'IApplicationService' will be registered automatically.
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                    .Where(t => typeof(IApplicationService).IsAssignableFrom(t) && !t.IsInterface).ToList()
                    .ForEach(type =>
                    {
                        services.AddTransient(type.GetInterface($"I{type.Name}")!, type);
                    });

            return services;
        }
    }
}
