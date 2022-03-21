using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal interface IProductDAO
    {
        void Add(Product produto);
        void Update(Product produto);
        void Delete(Product produto);
        IList<Product> Products();
    }
}
