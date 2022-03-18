namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string Categoria { get;  set; }
        public double Preco { get;  set; }

        public override string ToString()
        {
            return $"Produto: {Id, -10}\t{Nome,-20}\t{Categoria,-10}\t{Preco,-5}";
        }
    }
}