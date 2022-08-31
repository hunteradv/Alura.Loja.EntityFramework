using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Product
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Category { get;  set; }
        public double UnitValue { get;  set; }
        public string Unity { get; set; }
        //public IList<ProductPromotion> Promotions { get; set; }

        public override string ToString()
        {
            return $"Produto: {Id, -10}\t{Name,-20}\t{Category,-10}\t{UnitValue,-5}";
        }
    }
}