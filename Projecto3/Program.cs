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
            Console.WriteLine("Criar categorias de produtos");
            Console.Write("Digite o nome da primeira categoria: ");
            Categoria cat = new Categoria(Console.ReadLine());

            Console.Write("Digite o nome da segunda categoria: ");
            Categoria cat2 = new Categoria(Console.ReadLine());

            // Criar produtos e associá-los às categorias criadas
            Console.WriteLine("Criar produtos para as categorias criadas");

            Console.WriteLine("Digite o preço do primeiro produto: ");
            Console.Write("Digite o nome do primeiro produto: ");
            double preco1 = double.Parse(Console.ReadLine());
            
            Produto produto = new Produto(Console.ReadLine(), cat, preco1);

            Console.WriteLine("Digite o preço do segundo produto: ");
            Console.Write("Digite o nome do segundo produto: ");
           double preco2 = double.Parse(Console.ReadLine());
            Produto produto1 = new Produto(Console.ReadLine(), cat2, preco2);

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
            Console.WriteLine("por favor digite o nome da categoria para exibir os produtos da categoria");
            List<Produto> roupasEncontradas = estoque.BuscarPorCategoria(Console.ReadLine());
            foreach (Produto p in roupasEncontradas)
            {
                Console.WriteLine($"Nome: {p.Nome} \npreco: {p.Preco}");

            }
        }
    }
}
