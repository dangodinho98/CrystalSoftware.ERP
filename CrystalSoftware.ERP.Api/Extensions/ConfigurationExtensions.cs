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

            applicationConfig.EmailSettings.EmailFrom = source.GetSection("MailSettings").GetValue<string>("MailFrom");
            applicationConfig.EmailSettings.EmailFromPassword = source.GetSection("MailSettings").GetValue<string>("MailFromPassword");
            applicationConfig.EmailSettings.Host = source.GetSection("MailSettings").GetValue<string>("Host");
            applicationConfig.EmailSettings.Port = source.GetSection("MailSettings").GetValue<int>("Port");
            applicationConfig.EmailSettings.EnableSsl = source.GetSection("MailSettings").GetValue<bool>("EnableSsl");

            applicationConfig.Validate();
            return applicationConfig;
        }
    }
}
