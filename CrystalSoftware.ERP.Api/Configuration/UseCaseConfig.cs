using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.UseCases.Account;
using CrystalSoftware.ERP.UseCases.Person;
using Microsoft.Extensions.DependencyInjection;

namespace CrystalSoftware.ERP.Api.Configuration
{
    public static class UseCaseConfig
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddSingleton<ICreatePersonUseCase, CreatePersonUseCase>();
            services.AddSingleton<ICreateAccountUseCase, CreateAccountUseCase>();
        }
    }
}
