using Microsoft.EntityFrameworkCore;

namespace super_hero_api.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
