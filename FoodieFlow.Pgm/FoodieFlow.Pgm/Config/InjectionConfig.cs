using FoodieFlow.Pgm.Core.Interfaces.Repository;
using FoodieFlow.Pgm.Core.Interfaces.Service;
using FoodieFlow.Pgm.Core.Services;
using Scrutor;

namespace FoodieFlow.Pgm.Config
{
    public static class InjectionConfig
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, WebApplicationBuilder builder)
        {

            //services.AddScoped<IAwsService, AwsService>();
            //services.AddScoped<IProcessamentoPagamento, ProcessamentoPagamento>();

            builder.Services.Scan(scan => scan.FromApplicationDependencies()
            .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IBaseService<>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime()
            .AddClasses(classes => classes.InNamespaces("FoodieFlow.Pgm.Core.Services"))
                .AsMatchingInterface()
                .WithScopedLifetime()
            .AddClasses(classes => classes.InNamespaces("FoodieFlow.Pgm.Infra.Repository"))
                .AsMatchingInterface()
                .WithScopedLifetime()
             .AddClasses(classes => classes.InNamespaces("FoodieFlow.Pgm.Infra.Adapter"))
                .AsMatchingInterface()
                .WithScopedLifetime()
            );

            return services;
        }
    }
}

