using Alura.Loja.Testes.ConsoleApp;
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
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }

                Console.WriteLine("==================================");
                foreach (var entrie in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(entrie.State);
                }

                var firstProduct = products.Last();
                firstProduct.Nome = "Pulp Fiction";

                Console.WriteLine("==================================");
                foreach (var entrie in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(entrie.State);
                }

                context.SaveChanges();

                //Console.WriteLine("===================");
                //products = context.Produtos.ToList();
                //foreach (var product in products)
                //{
                //    Console.WriteLine(product);
                //}

            }

            Console.ReadKey();
        }
    }
}
