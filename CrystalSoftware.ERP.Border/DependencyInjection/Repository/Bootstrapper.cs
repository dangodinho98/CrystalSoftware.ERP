using Microsoft.Extensions.DependencyInjection;

namespace CrystalSoftware.ERP.Border.DependencyInjection.Repository
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            return services;
        }
    }
}
