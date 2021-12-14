using CrystalSoftware.ERP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrystalSoftware.ERP.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}
