using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextSugarCat.Core.Models;

namespace NextSugarCat.Persistance
{
    public class BakeryDbContext : IdentityDbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ItemPricePerSet> SetPrices { get; set; }
        public DbSet<MenuItemPrice> Prices { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FAQ> FAQ { get; set; }

        public BakeryDbContext(DbContextOptions<BakeryDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItemIngredient>().HasKey(mi =>
             new { mi.MenuItemId, mi.IngredientId });
        }
    }
}
