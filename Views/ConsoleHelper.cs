using RickAndMortyApp.Models;

namespace RickAndMortyApp.Views;

public static class ConsoleHelper
{
    public static void WriteTitle(string title)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"=== {title} ===");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void WriteFooter(int currentPage, PageInfo info)
    {
        Console.WriteLine($"Página {currentPage} de {info.Pages} | Total de registros: {info.Count} ");

    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void WaitForKey()
    {
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey(true);
    }
}