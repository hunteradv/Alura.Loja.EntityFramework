using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Produtos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProductPromotion>()
                .HasKey(pp => new { pp.ProductId, pp.PromotionId });

            modelBuilder
                .Entity<Address>()
                .ToTable("Addresses");

            modelBuilder
                .Entity<Address>()
                .Property<int>("ClientId");

            modelBuilder
                .Entity<Address>()
                .HasKey("ClientId");
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StoreDb;Trusted_Connection=true;");
        }
    }
}