using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Offices> Offices { get; set; }

        public DbSet<Shops> Shops { get; set; }

        public DbSet<Addresses> Addresses { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<StoreMenu> StoreMenu { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Rate> Rate { get; set; }

    }
}
