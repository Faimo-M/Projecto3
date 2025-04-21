using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha3.Modelos;

namespace Ficha3.Interfaces
{
    public interface IEstoqueServices
    {
        public void AdicionarProduto( Produto produto);// este metodo diz que vai receber um objecto do tipo produto
   
         List<Produto> ListarProdutos();// vai retornar uma lista com os produtos
        List<Produto> BuscarPorCategoria( string nomeCategoria); // vai retornar uma lista com produtos daquela categoria
    }
}
