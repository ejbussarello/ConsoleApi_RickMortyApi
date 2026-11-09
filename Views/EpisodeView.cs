using RickAndMortyApp.Views;
using RickAndMortyApp.Models;
using RickAndMortyApi.Views;

namespace RickAndMortyApp.Views;

public class EpisodeView
{
    public void ShowList(ApiResponse<Episode> response, int currentPage)
    {
        Console.Clear();
        ConsoleHelper.WriteTitle("EPISÓDIOS");

        foreach (var episode in response.Results)
        {
            Console.WriteLine($"[{episode.Code}] {episode.Name}");
            Console.WriteLine($"   Exibição: {episode.AirDate}");
            Console.WriteLine($"   Personagens: {episode.Characters.Count}");
            Console.WriteLine();
        }

        ConsoleHelper.WriteFooter(currentPage, response.Info);
    }
}