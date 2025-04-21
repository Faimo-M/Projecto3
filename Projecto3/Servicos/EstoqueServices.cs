using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha3.Interfaces;
using Ficha3.Modelos;

namespace Ficha3.Servicos
{
    public class EstoqueServices : IEstoqueServices
    {
        private List<Produto> produtos = new List<Produto>();


        public void AdicionarProduto(Produto produto)
        {
           produtos.Add(produto);
        }

        public List<Produto> BuscarPorCategoria(string nomeCategoria)
            /*este metodo criei uma lista resultado que recebe  todos
             * os produtos da categoria pesquisada
             */
        {
          List<Produto> resultado = new List<Produto>();
            foreach (Produto p in produtos) // para todos os produtos p em produtso
            {
                if(p.Categoria.Nome == nomeCategoria) 
                { 
                    resultado.Add(p);
                }
            }
            return resultado;
        }

        public List<Produto> ListarProdutos()
        {
            return produtos;
        }
    }
}
