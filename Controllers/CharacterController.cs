using RickAndMortyApp.Models;
using RickAndMortyApp.Services.Interfaces;
using RickAndMortyApp.Views;

namespace RickAndMortyApp.Controllers;

public class CharacterController : ListControllerBase<Character>
{
    private readonly IRickAndMortyService _service;
    private readonly CharacterView _view;

    public CharacterController(IRickAndMortyService service, CharacterView view)
    {
        _service = service;
        _view = view;
    }

    protected override Task<ApiResponse<Character>?> FetchAsync(int page, string? name)
        => _service.GetCharactersAsync(page, name);

    protected override void Display(ApiResponse<Character> response, int page)
        => _view.ShowList(response, page);
}