using RickAndMortyApp.Models;
using RickAndMortyApp.Services.Interfaces;
using RickAndMortyApp.Views;

namespace RickAndMortyApp.Controllers;

public class LocationController : ListControllerBase<Location>
{
    private readonly IRickAndMortyService _service;
    private readonly LocationView _view;

    public LocationController(IRickAndMortyService service, LocationView view)
    {
        _service = service;
        _view = view;
    }

    protected override Task<ApiResponse<Location>?> FetchAsync(int page, string? name)
        => _service.GetLocationsAsync(page, name);

    protected override void Display(ApiResponse<Location> response, int page)
        => _view.ShowList(response, page);
}