using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class ProductDAOEntity : IProductDAO, IDisposable
    {
        private StoreContext context;

        public ProductDAOEntity()
        {
            context = new StoreContext();
        }

        public void Add(Product produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
        }

        public void Delete(Product produto)
        {
            context.Produtos.Remove(produto);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IList<Product> Products()
        {
            return context.Produtos.ToList();
        }

        public void Update(Product produto)
        {
            context.Produtos.Update(produto);
            context.SaveChanges();
        }
    }
}
