using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal interface IProductDAO
    {
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
        IList<Produto> Products();
    }
}
