using CrystalSoftware.ERP.Border.Models;
using Microsoft.EntityFrameworkCore;

namespace CrystalSoftware.ERP.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public DbSet<People> People { get; set; }
    }
}
