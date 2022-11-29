//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using GameDrewTotal.Data.Entities;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;

//namespace GameDrewTotal.Data
//{
//    public class GameDrewDbContext : IdentityDbContext<StoreUser>
//    {

//        private readonly IConfiguration _config;

//        public GameDrewDbContext(IConfiguration config)
//        {
//            _config = config;
//        }


//        public DbSet<Product> Products { get; set; }
//        public DbSet<Order> Orders { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
//        {
//            base.OnConfiguring(bldr);

//            bldr.UseSqlServer(_config.GetConnectionString("GameDrewDbContextConnection"));
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.Entity<Product>()
//              .Property(p => p.Price)
//              .HasColumnType("money");

//            modelBuilder.Entity<OrderItem>()
//              .Property(o => o.UnitPrice)
//              .HasColumnType("money");

//            modelBuilder.Entity<Order>()
//              .HasData(new Order()
//              {
//                  Id = 1,
//                  OrderDate = DateTime.UtcNow,
//                  OrderNumber = "12345"
//              });
//        }
//    }
//}

using GameDrewTotal.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameDrewTotal.Data
{
    public class GameDrewDbContext : IdentityDbContext<StoreUser>
    {
        private readonly IConfiguration _config;

        public GameDrewDbContext(IConfiguration config)
        {
            _config = config;
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        {
            base.OnConfiguring(bldr);

            bldr.UseSqlServer(_config.GetConnectionString("GameDrewDbContextConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
              .HasColumnType("money");

            modelBuilder.Entity<OrderItem>()
              .Property(o => o.UnitPrice)
              .HasColumnType("money");

            modelBuilder.Entity<Order>()
              .HasData(new Order()
              {
                  Id = 1,
                  OrderDate = DateTime.UtcNow,
                  OrderNumber = "12345"
              });
        }
    }
}