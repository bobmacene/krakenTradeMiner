using Microsoft.EntityFrameworkCore;

namespace krakenTradeMiner.Models
{
    public class KrakenTradeMinerContext : DbContext
    {
        public DbSet<Trade> Trades { get; set; }
        public DbSet<MaId> MaIds { get; set; }
        public DbSet<DatabaseInfo> DatabaseInfo { get;set;   }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=krknDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>().Property(x => x.Price).HasPrecision(30, 5);
            modelBuilder.Entity<Trade>().Property(x => x.UnixTime).HasPrecision(30, 5);
            modelBuilder.Entity<Trade>().Property(x => x.Volume).HasPrecision(30, 8);
        }

       
    }

    

}
