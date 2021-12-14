using CrystalSoftware.ERP.Border;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CrystalSoftware.ERP.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BaseRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected T GetService<T>()
        {
            var scope = _serviceScopeFactory.CreateScope();
            var services = scope.ServiceProvider;
            return services.GetRequiredService<T>();
        }
    }
}
