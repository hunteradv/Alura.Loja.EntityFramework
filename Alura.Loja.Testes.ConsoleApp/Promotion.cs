using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public IList<ProductPromotion> Products { get; set; }

        public Promotion()
        {
            Products = new List<ProductPromotion>();
        }

        public void InsertProduct(Product product)
        {
            Products.Add(new ProductPromotion() { Product = product });
        }
    }
}
