using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Repositories;
using CrystalSoftware.ERP.Repositories.Account;
using CrystalSoftware.ERP.Repositories.Person;
using CrystalSoftware.ERP.Repositories.Services;
using CrystalSoftware.ERP.Shared.Configuration;
using Microsoft.AspNet.Identity;
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
            services.AddSingleton<IIdentityRepository, IdentityRepository>();
            services.AddSingleton<IFileManagerRepository, FileManagerRepository>();

            services.AddSingleton<IIdentityMessageService>(new MailService(applicationConfig.EmailSettings));
        }
    }
}
