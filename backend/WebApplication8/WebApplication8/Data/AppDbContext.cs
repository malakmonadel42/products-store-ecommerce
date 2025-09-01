using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet باسم Product بدل Item
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ربط الـ Model بالجدول الفعلي في قاعدة البيانات
            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            modelBuilder.Entity<Product>().Property(p => p.Price)
                                         .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                      new Product
                      {
                          Id = 1,
                          Name = "Accusantium Dolorem1",
                          Image = "images/product/large-size/1.jpg",
                          Price = 46.80m,
                          Qty = 1,
                          oldPrice = 50,      // only for some items
                          discount = 7
                      },
                      new Product
                      {
                          Id = 2,
                          Name = "Mug Today Is A Good Day",
                          Image = "images/product/large-size/2.jpg",
                          Price = 71.80m,
                          Qty = 2,
                          oldPrice = 77,      // only for some items
                          discount = 5
                      },
                      new Product
                      {
                          Id = 3,
                          Name = "Accusantium Dolorem1",
                          Image = "images/product/large-size/3.jpg",
                          Price = 46.80m,
                          Qty = 3
                          // no oldPrice or discount
                      },
                      new Product
                      {
                          Id = 4,
                          Name = "Mug Today Is A Good Day",
                          Image = "images/product/large-size/4.jpg",
                          Price = 71.80m,
                          Qty = 4
                          // no oldPrice or discount
                      },
                      new Product
                      {
                          Id = 5,
                          Name = "Accusantium Dolorem1",
                          Image = "images/product/large-size/5.jpg",
                          Price = 46.80m,
                          Qty = 5,
                          oldPrice = 50,
                          discount = 4
                      },
                      new Product
                      {
                          Id = 6,
                          Name = "Mug Today Is A Good Day",
                          Image = "images/product/large-size/6.jpg",
                          Price = 71.80m,
                          Qty = 6
                          // no oldPrice or discount
                      }
                   );

        }

    }
}
