using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace Identity
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<HairdresserService> HairdresserServices { get; set; }
        public DbSet<CosmeticService> CosmeticServices { get; set; }
        public DbSet<Manicure> Manicures { get; set; }
        public DbSet<BookingCosmeticService> BookingCosmeticServices { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}



