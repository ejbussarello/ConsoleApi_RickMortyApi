using RickAndMortyApp.Models;
using RickAndMortyApp.Views;

namespace RickAndMortyApp.Controllers;

public abstract class ListControllerBase<T>
{
    // O que muda de um controller para outro (cada filho implementa):
    protected abstract Task<ApiResponse<T>?> FetchAsync(int page, string? name);
    protected abstract void Display(ApiResponse<T> response, int page);

    // O que é igual para todos (o loop fica aqui, escrito uma vez):
    public async Task ShowAsync()
    {
        var page = 1;
        string? name = null;

        while (true)
        {
            ApiResponse<T>? response;

            try
            {
                response = await FetchAsync(page, name);
            }
            catch (HttpRequestException)
            {
                ConsoleHelper.WriteError("Falha de comunicação com a API. Verifique sua conexão com a internet.");
                ConsoleHelper.WaitForKey();
                return;
            }
            catch (TaskCanceledException)
            {
                ConsoleHelper.WriteError("A API demorou demais para responder. Tente novamente.");
                ConsoleHelper.WaitForKey();
                return;
            }

            if (response == null)
            {
                ConsoleHelper.WriteError("Nenhum resultado encontrado.");
                ConsoleHelper.WaitForKey();

                if (name == null)
                    return;

                // Havia um filtro: limpa e volta para a listagem completa.
                name = null;
                page = 1;
                continue;
            }

            Display(response, page);

            var command = ConsoleHelper.ReadNavigation(response.Info, name);

            switch (command)
            {
                case "N" when response.Info.Next != null:
                    page++;
                    break;
                case "P" when response.Info.Prev != null:
                    page--;
                    break;
                case "B":
                    name = ConsoleHelper.ReadSearchTerm();
                    page = 1;
                    break;
                case "0":
                    return;
                default:
                    ConsoleHelper.WriteError("Comando inválido.");
                    ConsoleHelper.WaitForKey();
                    break;
            }
        }
    }
}