using Alura.Loja.Testes.ConsoleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Alura.Loja.Testes.Aula08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StoreContext())
            {
                //Log
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var client = context
                    .Clients
                    .Include(x => x.DeliveryAddress)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {client.DeliveryAddress.Street}");


                var product = context
                    .Products
                    .Where(x => x.Id == 1002)
                    .FirstOrDefault();

                context.Entry(product)
                    .Collection(x => x.Orders)
                    .Query()
                    .Where(x => x.Total > 0.5)
                    .Load();


                Console.WriteLine($"Listando compras do produto {product.Name}");
                foreach (var item in product.Orders)
                {
                    Console.WriteLine(item.Product);
                }
            }
        }

        private static void ListPromoProducts()
        {
            using (var context2 = new StoreContext())
            {
                var promo = context2
                    .Promotions
                    .Include(x => x.Products)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefault();
                Console.WriteLine("Listando produtos da promoção...");

                foreach (var item in promo.Products)
                {
                    Console.WriteLine(item.Product);
                }
            }
        }

        private static void InsertPromotion()
        {
            using (var context = new StoreContext())
            {
                //Log
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promo = new Promotion()
                {
                    Description = "Queima total Janeiro 2023",
                    StartTime = new DateTime(2023, 01, 01),
                    FinishTime = new DateTime(2023, 01, 30)
                };

                var products = context.Products.Where(x => x.Category == "Filmes").ToList();

                foreach (var item in products)
                {
                    promo.InsertProduct(item);
                }

                context.Promotions.Add(promo);

                ShowEntries(context.ChangeTracker.Entries());

                context.SaveChanges();
            }
        }

        private static void ShowEntries(IEnumerable<EntityEntry> entries)
        {
            foreach (var entrie in entries)
            {
                Console.WriteLine(entrie.Entity.ToString() + " - " + entrie.State);
            }
        }
    }
}
