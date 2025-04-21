using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha3.Modelos
{
    public class Produto
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, Categoria categoria, double preco)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
        }

        


        public override string ToString()
        {
            return $"Nome: {Nome}, Categoria: {Categoria.Nome}, Preco: {Preco}";
        }
    }
}
