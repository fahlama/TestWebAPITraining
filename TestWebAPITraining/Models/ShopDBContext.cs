using Microsoft.EntityFrameworkCore;

namespace TestWebAPITraining.Models
{
    public class ShopDBContext:DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options):base(options)

        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> pies { get; set; }
        //public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
       // public DbSet<Order> Orders { get; set; }
       // public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
