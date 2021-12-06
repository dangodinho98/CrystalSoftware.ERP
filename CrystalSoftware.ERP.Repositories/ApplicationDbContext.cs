using CrystalSoftware.ERP.Border.Models;
using Microsoft.EntityFrameworkCore;

namespace CrystalSoftware.ERP.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<People> People { get; set; }
    }
}
