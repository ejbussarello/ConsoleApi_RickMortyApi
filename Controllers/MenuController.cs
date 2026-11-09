using RickAndMortyApi.Controller;
using RickAndMortyApp.Views;

namespace RickAndMortyApp.Controllers;

public class MenuController
{
    private readonly MenuView _menuView;
    private readonly CharacterController _characterController;
    private readonly LocationController _locationController;
    private readonly EpisodeController _episodeController;
    
    public MenuController(MenuView menuView, CharacterController characterController, LocationController locationController, EpisodeController episodeController)
    {
        _menuView = menuView;
        _characterController = characterController;
        _locationController = locationController;
        _episodeController = episodeController;
    }

    public async Task RunAsync()
    {
        var running = true;

        while (running)
        {
            _menuView.ShowMainMenu();
            var option = _menuView.ReadOption();

            switch (option)
            {
                case "1":
                    await _characterController.ShowAsync();
                    break;
                case "2":
                    await _locationController.ShowAsync();
                    break;
                case "3":
                    await _episodeController.ShowAsync();
                    break;
                case "0":
                    _menuView.ShowGoodbye();
                    running = false;
                    break;
                default:
                    _menuView.ShowInvalidOption();
                    break;
            }
        }
    }
}