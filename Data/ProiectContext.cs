using Microsoft.EntityFrameworkCore;
using ProiectV1.Models;

namespace ProiectV1.Data
{
    public class ProiectContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<DeliveryAdress> DeliveryAdresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductPromotion> ProductPromotions { get; set; }

        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to One
            modelBuilder.Entity<Order>()
                .HasOne<DeliveryAdress>(o => o.DeliveryAdress)
                .WithOne(da => da.Order)
                .HasForeignKey<DeliveryAdress>(da => da.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            //One to Many
            modelBuilder.Entity<Product>()
                .HasOne<Order>(p => p.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne<User>(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Many to Many
            modelBuilder.Entity<ProductPromotion>()
                .HasKey(pp => new { pp.ProductId, pp.PromotionId });

            modelBuilder.Entity<ProductPromotion>()
                .HasOne<Product>(pp => pp.Product)
                .WithMany(p => p.ProductPromotions)
                .HasForeignKey(pp => pp.ProductId);

            modelBuilder.Entity<ProductPromotion>()
               .HasOne<Promotion>(pp => pp.Promotion)
               .WithMany(p => p.ProductPromotions)
               .HasForeignKey(pp => pp.PromotionId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            base.OnModelCreating(modelBuilder);

        }

    }
}
