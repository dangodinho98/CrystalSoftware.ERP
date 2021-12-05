using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Interfaces;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Repositories.Account;
using CrystalSoftware.ERP.Repositories.Person;
using CrystalSoftware.ERP.Shared.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrystalSoftware.ERP.Api.Configuration
{
    public static class RepositoryConfig
    {
        public static void AddRepositories(this IServiceCollection services, ApplicationConfig applicationConfig)
        {
            services.AddHttpClient<IPersonRepository, PersonRepository>(client =>
            {
                client.BaseAddress = new Uri(applicationConfig.PersonApi.Url);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddSingleton<IAccountRepository, AccountRepository>();
            //services.AddSingleton<IAccountRepository>(sp => new AccountRepository(sp.GetService<UserManager<ApplicationUser>>()));
        }
    }
}
