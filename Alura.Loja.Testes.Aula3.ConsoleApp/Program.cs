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
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var products = context.Produtos.ToList();
                ShowEntries(context.ChangeTracker.Entries());

                var newProduct = new Produto()
                {
                    Nome = "Jojo Rabbit",
                    Categoria = "Filmes",
                    Preco = 2.99
                };
                context.Produtos.Add(newProduct);

                ShowEntries(context.ChangeTracker.Entries());

                context.SaveChanges();
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
