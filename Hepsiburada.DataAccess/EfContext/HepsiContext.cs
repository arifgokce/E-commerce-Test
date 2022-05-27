using Hepsiburada.Entities.EfEntities;
using Microsoft.EntityFrameworkCore;

namespace Hepsiburada.DataAccess.EfContext
{
    public class HepsiContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<IncreaseTime> IncreaseTime { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=94.73.146.5;initial catalog=Hepsi;user id=HepsiUser;password=JFwh46R3XCnr41O;MultipleActiveResultSets=True;App=EntityFramework;");
        }
    }
}
