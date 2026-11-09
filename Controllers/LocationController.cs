
using RickAndMortyApp.Services.Interfaces;
using RickAndMortyApp.Views;

namespace RickAndMortyApp.Controllers;

public class LocationController
{
    private readonly IRickAndMortyService _service;
    private readonly LocationView _view;

    public LocationController(IRickAndMortyService service, LocationView view)
    {
        _service = service;
        _view = view;
    }

    public async Task ShowAsync()
    {
        var response = await _service.GetLocationsAsync();

        if (response == null) ConsoleHelper.WriteError("Não foi possível obter as localizações.");
        else _view.ShowList(response, 1);

        ConsoleHelper.WaitForKey();
    }
}