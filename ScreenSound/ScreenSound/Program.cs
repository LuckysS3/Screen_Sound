using ScreenSound.Menus;
using ScreenSound.Modelos;

Banda Park = new("Linkin Park");
Park.AdicionarNota(new Avaliacao(10));
Park.AdicionarNota(new Avaliacao(8));
Park.AdicionarNota(new Avaliacao(6));
Banda Beatles = new("The Beatles");

Dictionary<string, Banda> bandasRegistradas = new();
bandasRegistradas.Add("Linkin Park", Park);
bandasRegistradas.Add("The Beatles", Beatles);

Dictionary<int, Menu> opecao = new();
opecao.Add(1, new RegistrarBanda());
opecao.Add(2, new RegistrarAlbum());
opecao.Add(3, new MostrarBandasRegistradas());
opecao.Add(4, new MenuAvaliarBanda());
opecao.Add(5, new MenuAvaliarAlbum());
opecao.Add(6, new MenuExibirDetalhes());
opecao.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    try
    {
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para registrar uma banda");
        Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
        Console.WriteLine("Digite 3 para mostrar todas as bandas");
        Console.WriteLine("Digite 4 para avaliar uma banda");
        Console.WriteLine("Digite 5 para avaliar uma album");
        Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
        Console.WriteLine("Digite -1 para sair");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        if (opecao.ContainsKey(opcaoEscolhidaNumerica))
        {
            Menu menu = opecao[opcaoEscolhidaNumerica];
            menu.Executar(bandasRegistradas);
            if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine("Opeçao nao existe");
            ExibirOpcoesDoMenu();
        }
    }catch (Exception ex)
    {
        Console.WriteLine($"Aconteceu alguma coisa de errado {ex.Message}");
    }
    finally
    {
        Console.WriteLine($"Tchau");
    }
}
    

ExibirOpcoesDoMenu();