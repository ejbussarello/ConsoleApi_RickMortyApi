using RickAndMortyApp.Services.Interfaces;
using RickAndMortyApp.Views;

namespace RickAndMortyApi.Controller;

public class EpisodeController
{
    private readonly IRickAndMortyService _service;
    private readonly EpisodeView _view;

    public EpisodeController(IRickAndMortyService service, EpisodeView view)
    {
        _service = service;
        _view = view;
    }

    public async Task ShowAsync()
    {
        var response = await _service.GetEpisodesAsync();

        if (response == null) ConsoleHelper.WriteError("Não foi possível obter os episódios.");
        else _view.ShowList(response, 1);

        ConsoleHelper.WaitForKey();
    }
}