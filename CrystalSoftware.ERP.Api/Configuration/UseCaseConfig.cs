using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.UseCases.Person;
using Microsoft.Extensions.DependencyInjection;

namespace CrystalSoftware.ERP.Api.Configuration
{
    public static class UseCaseConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICreatePersonUseCase, CreatePersonUseCase>();
        }
    }
}
