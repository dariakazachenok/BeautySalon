using Microsoft.EntityFrameworkCore;
using Models;

namespace EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<HairdresserService> HairdresserServices { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        } 

    }
}




