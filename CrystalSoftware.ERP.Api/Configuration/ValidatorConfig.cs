using CrystalSoftware.ERP.Border.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CrystalSoftware.ERP.Api.Configuration
{
    public static class ValidatorConfig
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddSingleton<StringValidator>();
            services.AddSingleton<GuidValidator>();
            services.AddSingleton<CreatePersonValidator>();
        }
    }
}
