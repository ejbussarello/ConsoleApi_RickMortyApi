using RickAndMortyApp.Views;

namespace RickAndMortyApp.Views;

public class MenuView
{
    public void ShowMainMenu()
    {
        Console.Clear();
        ConsoleHelper.WriteTitle("RICK AND MORTY EXPLORER");
        Console.WriteLine("1. Personagens");
        Console.WriteLine("2. Localizações");
        Console.WriteLine("3. Episódios");
        Console.WriteLine("0. Sair");
        Console.WriteLine();
    }

    public string? ReadOption()
    {
        Console.Write("Escolha uma opção: ");
        return Console.ReadLine();
    }

    public void ShowInvalidOption()
    {
        ConsoleHelper.WriteError("Opção inválida. Tente novamente.");
        ConsoleHelper.WaitForKey();
    }

    public void ShowGoodbye()
    {
        Console.Clear();
        ConsoleHelper.WriteTitle("Obrigado por usar o Rick and Morty Explorer!");
        ConsoleHelper.WaitForKey();
    }
}