
using RickAndMortyApi.Views;
using RickAndMortyApp.Models;

namespace RickAndMortyApp.Views;

public class CharacterView
{
    public void ShowList(ApiResponse<Character> response, int currentPage)
    {
        Console.Clear();
        ConsoleHelper.WriteTitle(" PERSONAGENS");

        foreach (var character in response.Results)
        {
            Console.Write($"#{character.Id} - {character.Name} - ");
            WriteStatus(character.Status);

            Console.WriteLine($"   Espécie: {character.Species} | Gênero: {character.Gender}");
            Console.WriteLine($"   Origem: {character.Origin.Name}");
            Console.WriteLine($"   Local atual: {character.Location.Name}");
            Console.WriteLine($"   Aparições: {character.Episodes.Count} episódios");
            Console.WriteLine();
        }

        ConsoleHelper.WriteFooter(currentPage, response.Info);
    }

    private static void WriteStatus(string status)
    {
        Console.ForegroundColor = status switch
        {
            "Alive" => ConsoleColor.Green,
            "Dead" => ConsoleColor.Red,
            _ => ConsoleColor.Yellow
        };

        Console.WriteLine(status);
        Console.ResetColor();
    }

}