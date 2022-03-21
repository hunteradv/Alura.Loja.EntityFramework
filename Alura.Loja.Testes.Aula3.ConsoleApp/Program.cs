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

namespace Alura.Loja.Testes.Aula3.ConsoleApp
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

                //select de produtos
                var products = context.Produtos.ToList();

                ShowEntries(context.ChangeTracker.Entries());

                var newProduct = new Product()
                {
                    Name = "Field Of Dreams",
                    Category = "Filmes",
                    UnityValue = 20.99
                };
                context.Produtos.Add(newProduct);

                ShowEntries(context.ChangeTracker.Entries());

                context.Remove(newProduct);;
                 
                ShowEntries(context.ChangeTracker.Entries());

                //context.SaveChanges();

                var entry = context.Entry(newProduct);

                Console.Write("\n\n" + entry.Entity.ToString() + " - " + entry.State);
            }

            Console.ReadKey();
        }

        private static void ShowEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("==================================");
            foreach (var entrie in entries)
            {
                Console.WriteLine(entrie.Entity.ToString() + " - " + entrie.State);
            }
        }
    }
}
