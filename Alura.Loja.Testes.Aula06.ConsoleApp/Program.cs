using Alura.Loja.Testes.ConsoleApp;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.Aula06.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Product()
            {
                Name = "Ovo simples",
                Category = "Ovos de pascoa",
                Unity = "Unidade",
                UnitValue = 10
            };


            var p2 = new Product()
            {
                Name = "Ovo Stranger Things",
                Category = "Ovos de páscoa",
                Unity = "Unidade",
                UnitValue = 130.99
            };

            var p3 = new Product()
            {
                Name = "Ovo Nescau",
                Category = "Ovos de páscoa",
                Unity = "Unidade",
                UnitValue = 70.99
            };

            var easterPromotion = new Promotion()
            {
                Description = "Páscoa Feliz",
                StartTime = DateTime.Now,
                FinishTime = DateTime.Now.AddMonths(1),
            };

            easterPromotion.InsertProduct(p1);
            easterPromotion.InsertProduct(p2);
            easterPromotion.InsertProduct(p3);

            using (var context = new StoreContext())
            {
                //Log
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                //context.Promotions.Add(easterPromotion);
                var promotion = context.Promotions.Find(1);
                context.Promotions.Remove(promotion);
                ShowEntries(context.ChangeTracker.Entries());
                context.SaveChanges();
            }


            Console.ReadKey();
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
