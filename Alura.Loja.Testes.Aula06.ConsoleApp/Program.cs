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
            var easterPromotion = new Promotion();

            using (var context = new StoreContext())
            {
                //Log
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());                
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
