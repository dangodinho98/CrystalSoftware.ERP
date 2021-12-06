using Microsoft.EntityFrameworkCore;

namespace CrystalSoftware.ERP.Repositories
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)
        { }

        public DbSet<Border.Models.Person> People { get; set; }
    }
}
