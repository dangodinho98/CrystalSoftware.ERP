using CrystalSoftware.ERP.Shared.Configuration;
using Microsoft.Extensions.Configuration;

namespace CrystalSoftware.ERP.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ApplicationConfig LoadConfiguration(this IConfiguration source)
        {
            var applicationConfig = source.Get<ApplicationConfig>();

            applicationConfig.Database.ConnectionString = source.GetConnectionString("SqlServer");
            applicationConfig.Database.DatabaseName = source.GetConnectionString("DatabaseName");
            applicationConfig.PersonApi.Url = source.GetSection("Person").GetValue<string>("baseUrl");

            applicationConfig.Validate();

            return applicationConfig;
        }
    }
}
