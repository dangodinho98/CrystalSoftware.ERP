using System.Data.Entity;
using CrystalSoftware.ERP.Border.Models;
using CrystalSoftware.ERP.Shared.Configuration;

namespace CrystalSoftware.ERP.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(ApplicationConfig application)
            : base(application.Database.ConnectionString)
        {
        }

        public DbSet<People> People { get; set; }
    }
}
