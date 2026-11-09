
using RickAndMortyApp.Views;
using RickAndMortyApp.Services.Interfaces;

namespace RickAndMortyApp.Controllers;

public class CharacterController
{
    private readonly IRickAndMortyService _service;
    private readonly CharacterView _view;

    public CharacterController(IRickAndMortyService service, CharacterView view)
    {
        _service = service;
        _view = view;
    }

    public async Task ShowAsync()
    {
        var response = await _service.GetCharactersAsync();

        if (response == null) ConsoleHelper.WriteError("Não foi possível obter os personagens.");
        else _view.ShowList(response, 1);

        ConsoleHelper.WaitForKey();
    }
}