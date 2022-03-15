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

        public void Add(Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            context.Produtos.Update(produto);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IList<Produto> Products()
        {
            return context.Produtos.ToList();
        }

        public void Update(Produto produto)
        {
            context.Produtos.Remove(produto);
            context.SaveChanges();
        }
    }
}
