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

namespace Alura.Loja.Testes.Aula07.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cli1 = new Client
            {
                Name = "Gustavo",
                DeliveryAddress = new Address()
                {
                    Number = 170,
                    Street = "Rua Rue Bennett",
                    Complement = "Sobrado",
                    District = "Bairro Euphoria",
                    City = "São José do Rio Preto"
                }
            };

            using (var context = new StoreContext())
            {
                //Log
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                context.Clients.Add(cli1);
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
