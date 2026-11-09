using RickAndMortyApp.Services;

var service = new RickAndMortyService(new HttpClient());
var result = await service.GetCharactersAsync();

Console.WriteLine($"Total de personagens: {result?.Info.Count}");
Console.WriteLine($"Primeiro: {result?.Results.FirstOrDefault()?.Name}");