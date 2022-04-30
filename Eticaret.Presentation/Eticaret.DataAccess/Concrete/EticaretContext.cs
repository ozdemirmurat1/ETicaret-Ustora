



using Eticaret.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.DataAccess.Concrete
{
    public class EticaretContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //185.242.162.113
            //db1_otel
            //db1_otel
            //Abc123@@

            optionsBuilder.UseSqlServer("Data Source=185.242.162.113;Initial Catalog=db1_otel;User ID=db1_otel;Password=Abc123@@");
        }
        public DbSet<User> Users {get;set;}
        public DbSet<UserToken> UserTokens {get;set; }
        public DbSet<Category> Categories {get;set; }
        public DbSet<Slider> Sliders {get;set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; } // ekle
    }
}
