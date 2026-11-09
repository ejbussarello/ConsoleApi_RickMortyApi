using System.Text;
using Microsoft.Extensions.DependencyInjection;

using RickAndMortyApp.Controllers;
using RickAndMortyApp.Services;
using RickAndMortyApp.Services.Interfaces;
using RickAndMortyApp.Views;

// Garante que acentos apareçam corretamente no console
Console.OutputEncoding = Encoding.UTF8;

// 1. Registro: dizemos ao container o que existe
var services = new ServiceCollection();

services.AddHttpClient<IRickAndMortyService, RickAndMortyService>();

services.AddTransient<MenuView>();
services.AddTransient<CharacterView>();
services.AddTransient<LocationView>();
services.AddTransient<EpisodeView>();

services.AddTransient<CharacterController>();
services.AddTransient<LocationController>();
services.AddTransient<EpisodeController>();
services.AddTransient<MenuController>();

// 2. Construção: o container cria os objetos e resolve as dependências
var provider = services.BuildServiceProvider();

// 3. Uso: pedimos o objeto principal; o resto é resolvido automaticamente pelo container
var app = provider.GetRequiredService<MenuController>();
await app.RunAsync();