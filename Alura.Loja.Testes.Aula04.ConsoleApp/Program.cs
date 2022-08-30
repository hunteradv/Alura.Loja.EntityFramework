using Alura.Loja.Testes.ConsoleApp;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.Aula04.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //compra de 6 pães franceses

            var frenchBread = new Product()
            {
                Name = "Pão Francês",
                UnitValue = 0.50,
                Category = "Padaria",
                Unity = "Unidade"
            };

            var order = new Order();

            order.Quantity = 6;
            order.Product = frenchBread;
            order.Total = (int)(frenchBread.UnitValue * order.Quantity);

            using (var context = new StoreContext())
            {
                //Log
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                context.Orders.Add(order);

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
