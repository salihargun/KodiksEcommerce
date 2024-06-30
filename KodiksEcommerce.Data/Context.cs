using KodiksEcommerce.Data.EntityFreamwork.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Data
{
    //public class Context : DbContext
    //{
    //    public Context(DbContextOptions<Context> options) : base(options) { }

    //    public DbSet<Customer> Customers { get; set; }
    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<Order> Orders { get; set; }
    //    public DbSet<MapOrderProduct> OrderProducts { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        // MapOrderProduct tablosunun birincil anahtarını tanımlar
    //        modelBuilder.Entity<MapOrderProduct>()
    //            .HasKey(op => new { op.OrderId, op.ProductId });

    //        // MapOrderProduct ve Order arasında bire çok ilişki tanımlar
    //        modelBuilder.Entity<MapOrderProduct>()
    //            .HasOne(op => op.Order)
    //            .WithMany(o => o.OrderProducts)
    //            .HasForeignKey(op => op.OrderId);

    //        // MapOrderProduct ve Product arasında bire çok ilişki tanımlar
    //        modelBuilder.Entity<MapOrderProduct>()
    //            .HasOne(op => op.Product)
    //            .WithMany(p => p.OrderProducts)
    //            .HasForeignKey(op => op.ProductId);

    //        // Order ve Customer arasında bire çok ilişki tanımlar
    //        modelBuilder.Entity<Order>()
    //            .HasOne(o => o.Customer)
    //            .WithMany(c => c.Orders)
    //            .HasForeignKey(o => o.CustomerId);
    //    }
    //}

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MapOrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MapOrderProduct tablosunun birincil anahtarını tanımlar
            modelBuilder.Entity<MapOrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            // MapOrderProduct ve Order arasında bire çok ilişki tanımlar
            modelBuilder.Entity<MapOrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            // MapOrderProduct ve Product arasında bire çok ilişki tanımlar
            modelBuilder.Entity<MapOrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            // Order ve Customer arasında bire çok ilişki tanımlar
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // Decimal alanlar için hasPrecision veya hasColumnType kullanarak hassasiyet belirleyin
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("SqlConnection",
                    b => b.MigrationsAssembly("KodiksEcommerce.Data"));
            }
        }
    }

}
