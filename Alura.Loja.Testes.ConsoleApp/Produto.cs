﻿namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Category { get;  set; }
        public double UnityValue { get;  set; }
        public string Unity { get; set; }

        public override string ToString()
        {
            return $"Produto: {Id, -10}\t{Name,-20}\t{Category,-10}\t{UnityValue,-5}";
        }
    }
}