﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //SaveUsingEntity();
            //RecoveryProducts();
            //DeleteProduct();
            //RecoveryProducts();
            UpdateProducts();

            Console.ReadKey();
        }

        private static void UpdateProducts()
        {
            //inclui um produto
            SaveUsingEntity();
            RecoveryProducts();

            //atualiza produto
            using(var context = new ProductDAOEntity())
            {
                Product first = context.Products().First();
                first.Name = "Laranja Mecânica (1971)";
                context.Update(first);
            }
            RecoveryProducts();
        }

        private static void DeleteProduct()
        {
            using(var context = new ProductDAOEntity())
            {
                IList<Product> products = context.Products().ToList();
                foreach (var product in products)
                {
                    context.Delete(product);
                }
            }
        }

        private static void RecoveryProducts()
        {
            using (var context = new ProductDAOEntity())
            {
                IList<Product> products = context.Products().ToList();
                Console.WriteLine($"Foram encontrados {products.Count} produto(s)");
                foreach (var product in products)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }

        private static void SaveUsingEntity()
        {
            Product p = new Product
            {
                Name = "Laranja Mecânica",
                Category = "Filmes",
                UnitValue = 89.95
            };

            using (var context = new ProductDAOEntity())
            {
                context.Add(p);
            }
        }
    }
}
