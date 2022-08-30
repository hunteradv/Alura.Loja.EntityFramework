using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class ProductDAOEntity : IProductDAO, IDisposable
    {
        private readonly StoreContext _context;

        public ProductDAOEntity()
        {
            _context = new StoreContext();
        }

        public void Add(Product produto)
        {
            _context.Products.Add(produto);
            _context.SaveChanges();
        }

        public void Delete(Product produto)
        {
            _context.Products.Remove(produto);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<Product> Products()
        {
            return _context.Products.ToList();
        }

        public void Update(Product produto)
        {
            _context.Products.Update(produto);
            _context.SaveChanges();
        }
    }
}
