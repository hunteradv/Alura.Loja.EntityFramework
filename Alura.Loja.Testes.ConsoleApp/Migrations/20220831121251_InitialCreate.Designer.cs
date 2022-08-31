using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Alura.Loja.Testes.ConsoleApp;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20220831121251_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Address", b =>
                {
                    b.Property<int>("ClientId");

                    b.Property<string>("City");

                    b.Property<string>("Complement");

                    b.Property<string>("District");

                    b.Property<int>("Number");

                    b.Property<string>("Street");

                    b.HasKey("ClientId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Name");

                    b.Property<double>("UnitValue");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.ProductPromotion", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("PromotionId");

                    b.HasKey("ProductId", "PromotionId");

                    b.HasIndex("PromotionId");

                    b.ToTable("ProductPromotion");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("FinishTime");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Address", b =>
                {
                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Client", "Client")
                        .WithOne("DeliveryAddress")
                        .HasForeignKey("Alura.Loja.Testes.ConsoleApp.Address", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.Order", b =>
                {
                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alura.Loja.Testes.ConsoleApp.ProductPromotion", b =>
                {
                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alura.Loja.Testes.ConsoleApp.Promotion", "Promotion")
                        .WithMany("Products")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
