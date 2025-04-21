using Ficha3.Interfaces;
using Ficha3.Modelos;
using Ficha3.Servicos;
using Ficha3.Utilitarios;

namespace Projecto3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // criar as categorias dos produtos
            Categoria roupas = new Categoria("Roupas");
            Categoria eletronicos = new Categoria("Eletronicos");

            //criar produtos
            Produto produto = new Produto("cac", roupas, 255);
            Produto produto1 = new Produto("laptop", eletronicos, 1500);

            //adicionar produtos ao estoque

            IEstoqueServices estoque = new EstoqueServices();
            if (Validador.Validar(produto))//vai verificar se o produto eh valido
            {
                estoque.AdicionarProduto(produto);
                estoque.AdicionarProduto(produto1);
            }
            else
            {
                Console.WriteLine($"Produto invalido: {produto.Nome}");
            }

            // listar todos os produtos

            List<Produto> todosProdutos = estoque.ListarProdutos();
            Console.WriteLine(" a listar todos Produtos ");
            foreach (Produto p in todosProdutos)
            {
                Console.WriteLine($"Nome: {p.Nome} \npreco: {p.Preco} \nCategoria: {p.Categoria.Nome}");
            }

            //pesquiar por categoria
            Console.WriteLine("prodtudos da categoria roupas");
            List<Produto> roupasEncontradas = estoque.BuscarPorCategoria("roupas");
            foreach (Produto p in roupasEncontradas)
            {
                Console.WriteLine($"Nome: {p.Nome} \npreco: {p.Preco}");

            }
        }
    }
}
