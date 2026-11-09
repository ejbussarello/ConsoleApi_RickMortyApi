using RickAndMortyApi.Views;
using RickAndMortyApp.Models;

namespace RickAndMortyApp.Views;

public class LocationView
{
    public void ShowList(ApiResponse<Location> response, int currentPage)
    {
        Console.Clear();
        ConsoleHelper.WriteTitle(" LOCALIZAÇÕES");

        foreach (var location in response.Results)
        {
            Console.WriteLine($"#{location.Id} - {location.Name}");
            Console.WriteLine($"   Tipo: {location.Type}");
            Console.WriteLine($"   Dimensão: {location.Dimension}");
            Console.WriteLine($"   Residentes: {location.Residents.Count}");
            Console.WriteLine();
        }

        ConsoleHelper.WriteFooter(currentPage, response.Info);
    }
}