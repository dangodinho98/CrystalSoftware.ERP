using CrystalSoftware.ERP.Border;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrystalSoftware.ERP.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        //public DbSet<Person> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Project>(entity =>
            //{
            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            base.OnModelCreating(builder);
        }
    }
}
