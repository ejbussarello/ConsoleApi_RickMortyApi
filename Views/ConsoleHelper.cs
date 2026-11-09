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

    public static string ReadNavigation(PageInfo info, string? filter)
    {
        Console.WriteLine();

        if (filter != null)
            Console.WriteLine($"Filtro ativo: \"{filter}\"");

        var options = new List<string>();

        if (info.Prev != null) options.Add("[P] Anterior");
        if (info.Next != null) options.Add("[N] Próxima");
        options.Add("[B] Buscar por nome");
        options.Add("[0] Voltar");

        Console.WriteLine(string.Join("  ", options));
        Console.Write("> ");

        return (Console.ReadLine() ?? string.Empty).Trim().ToUpperInvariant();
    }

    public static string? ReadSearchTerm()
    {
        Console.Write("Digite o nome (vazio para limpar o filtro): ");
        var term = Console.ReadLine()?.Trim();

        return string.IsNullOrEmpty(term) ? null : term;
    }
}