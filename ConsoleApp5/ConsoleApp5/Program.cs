using System;
using System.Collections.Generic;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class Program
{
    private static List<Produto> produtos = new List<Produto>();
    private static int id = 1;

    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1. Adicionar Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Editar Produto");
            Console.WriteLine("4. Excluir Produto");
            Console.WriteLine("5. Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    EditarProduto();
                    break;
                case "4":
                    ExcluirProduto();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarProduto()
    {
        Console.WriteLine("Digite o nome do produto:");
        string nome = Console.ReadLine();

        Produto produto = new Produto
        {
            Id = id,
            Nome = nome
        };

        produtos.Add(produto);
        id++;

        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void ListarProdutos()
    {
        Console.WriteLine("Lista de Produtos:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}");
        }
    }

    static void EditarProduto()
    {
        Console.WriteLine("Digite o ID do produto que deseja editar:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var produto = produtos.Find(p => p.Id == id);
            if (produto != null)
            {
                Console.WriteLine("Digite o novo nome do produto:");
                produto.Nome = Console.ReadLine();
                Console.WriteLine("Produto editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void ExcluirProduto()
    {
        Console.WriteLine("Digite o ID do produto que deseja excluir:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var produto = produtos.Find(p => p.Id == id);
            if (produto != null)
            {
                produtos.Remove(produto);
                Console.WriteLine("Produto excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }
}
