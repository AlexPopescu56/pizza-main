using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }
        public DbSet<ContosoPizza.Models.Pizza>? Pizzas { get; set; }
        public DbSet<ContosoPizza.Models.Pasta>? Pastas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContosoPizza.Models.Pizza>().Property(p => p.Size).HasConversion<string>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
