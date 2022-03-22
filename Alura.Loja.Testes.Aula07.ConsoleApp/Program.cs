using Alura.Loja.Testes.ConsoleApp;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            var cli1 = new Client();
            cli1.Name = "Gustavo";
            cli1.DeliveryAddress = new Address()
            {
                Number = 170,
                Street = "Rua Rue Bennett",
                District = "Sobrado",
                City = "São José do Rio Preto"
            };

            using (var context = new StoreContext())
            {
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
