using System;
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
            DeleteProduct();

            Console.ReadKey();
        }

        private static void DeleteProduct()
        {
            using(var context = new StoreContext())
            {
                IList<Produto> products = context.Produtos.ToList();
                foreach(var product in products)
                {

                }
            }
        }

        private static void RecoveryProducts()
        {
            using (var context = new StoreContext())
            {
                IList<Produto> products = context.Produtos.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product.Nome);
                }
            }
        }

        private static void SaveUsingEntity()
        {
            Produto p = new Produto();
            p.Nome = "Laranja Mecânica";
            p.Categoria = "Filmes";
            p.Preco = 89.95;

            using (var context = new StoreContext())
            {
                context.Add(p);
                context.SaveChanges();
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
