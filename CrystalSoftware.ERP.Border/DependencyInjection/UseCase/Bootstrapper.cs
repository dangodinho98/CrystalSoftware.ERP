using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace CrystalSoftware.ERP.Border.DependencyInjection.UseCase
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddUseCase(this IServiceCollection services)
        {
            //services.AddSingleton<IPersonUseCase>();
            return services;
        }
    }
}
