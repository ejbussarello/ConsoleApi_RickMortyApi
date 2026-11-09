using RickAndMortyApp.Models;
using RickAndMortyApp.Services.Interfaces;
using RickAndMortyApp.Views;

namespace RickAndMortyApp.Controllers;

public class EpisodeController : ListControllerBase<Episode>
{
    private readonly IRickAndMortyService _service;
    private readonly EpisodeView _view;

    public EpisodeController(IRickAndMortyService service, EpisodeView view)
    {
        _service = service;
        _view = view;
    }

    protected override Task<ApiResponse<Episode>?> FetchAsync(int page, string? name)
        => _service.GetEpisodesAsync(page, name);

    protected override void Display(ApiResponse<Episode> response, int page)
        => _view.ShowList(response, page);
}