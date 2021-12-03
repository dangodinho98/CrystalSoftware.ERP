using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Repositories.Person;
using Microsoft.Extensions.DependencyInjection;

namespace CrystalSoftware.ERP.Api.Configuration
{
    public static class RepositoryConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IPersonRepository, PersonRepository>();
        }
    }
}
