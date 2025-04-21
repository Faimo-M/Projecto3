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
            // Criação de um objeto do tipo EstoqueServices
            IEstoqueServices estoque = new EstoqueServices();
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Bem-vindo ao sistema de estoque de produtos!");
                Console.WriteLine("1.Adicionar Produtos");
                Console.WriteLine("2.Listar todos Produtos");
                Console.WriteLine("3.Buscar Produtos por categoria");
                Console.WriteLine("4.Sair");

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Por favor, insira um número válido.");
                continue;
            }
            
            
                switch (opcao)
                {
                    case 1:
                        AdicionarProdutos(estoque);
                        break;
                    case 2:
                        ListarProdutos(estoque);
                        break;
                    case 3:
                        BuscarProdutosPorCategoria(estoque);
                        break;
                    case 4:
                        Console.WriteLine("Sair");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

        static void AdicionarProdutos(IEstoqueServices estoque)
        {
            Console.WriteLine("Criar categorias de produtos");
            Console.Write("Digite o nome da primeira categoria: ");
            Categoria cat = new Categoria(Console.ReadLine());

            Console.Write("Digite o nome da segunda categoria: ");
            Categoria cat2 = new Categoria(Console.ReadLine());

            Console.WriteLine("Criar produtos para as categorias criadas");

            Console.WriteLine("Digite o preço do primeiro produto: ");
            Console.Write("Digite o nome do primeiro produto: ");
            double preco1 = double.Parse(Console.ReadLine());
            Produto produto = new Produto(Console.ReadLine(), cat, preco1);

            Console.WriteLine("Digite o preço do segundo produto: ");
            Console.Write("Digite o nome do segundo produto: ");
            double preco2 = double.Parse(Console.ReadLine());
            Produto produto1 = new Produto(Console.ReadLine(), cat2, preco2);

            if (Validador.Validar(produto))
            {
                estoque.AdicionarProduto(produto);
                estoque.AdicionarProduto(produto1);
                Console.WriteLine("Produtos adicionados com sucesso!");
            }
            else
            {
                Console.WriteLine($"Produto inválido: {produto.Nome}");
            }
        }

        static void ListarProdutos(IEstoqueServices estoque)
        {
            List<Produto> todosProdutos = estoque.ListarProdutos();
            Console.WriteLine("Listando todos os produtos:");
            foreach (Produto p in todosProdutos)
            {
                Console.WriteLine($"Nome: {p.Nome} \nPreço: {p.Preco} \nCategoria: {p.Categoria.Nome}");
            }
        }

        static void BuscarProdutosPorCategoria(IEstoqueServices estoque)
        {
            Console.WriteLine("Por favor, digite o nome da categoria para exibir os produtos:");
            string categoria = Console.ReadLine();
            List<Produto> produtosEncontrados = estoque.BuscarPorCategoria(categoria);

            if (produtosEncontrados.Count > 0)
            {
                foreach (Produto p in produtosEncontrados)
                {
                    Console.WriteLine($"Nome: {p.Nome} \nPreço: {p.Preco}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto encontrado para a categoria informada.");
            }
        }
    }
}
