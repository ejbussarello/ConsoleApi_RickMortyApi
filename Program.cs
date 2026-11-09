using RickAndMortyApp.Services;
using RickAndMortyApp.Views;

var service = new RickAndMortyService(new HttpClient());

var characters = await service.GetCharactersAsync();
if (characters != null)
{
    new CharacterView().ShowList(characters, 1);
}