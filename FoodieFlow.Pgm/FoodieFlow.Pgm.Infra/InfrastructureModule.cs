using FoodieFlow.Pgm.Core.Interfaces.repository;
using FoodieFlow.Pgm.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FoodieFlow.Pgm.Infra
{
    public static class InfrastructureModule
    {
        public static void RegisterInfrastructureModule(this IServiceCollection services)
        {
            services.AddSingleton<IEntityRepository, EntityRepository>();
        }
    }
}
