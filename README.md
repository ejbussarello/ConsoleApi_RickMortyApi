# Rick and Morty Explorer

Aplicação de console em **C# (.NET)** que consome a [Rick and Morty API](https://rickandmortyapi.com) e permite explorar personagens, localizações e episódios direto no terminal.

Este projeto foi criado com um objetivo didático: mostrar, passo a passo, como estruturar uma aplicação em camadas (**Models, Views, Controllers e Services**), usando interfaces e injeção de dependência, mantendo o código simples.

---

## O que a aplicação faz

- Menu interativo no console para escolher o que explorar
- Lista **personagens**, **localizações** e **episódios** vindos da API
- **Paginação**: navegue entre as páginas com `N` (próxima) e `P` (anterior)
- **Busca por nome**: filtre os resultados com `B`
- **Tratamento de erros**: mensagens claras para busca sem resultado, falta de internet e timeout
- Status dos personagens com cores (verde para vivo, vermelho para morto)

### Exemplo de saída

<img width="442" height="478" alt="image" src="https://github.com/user-attachments/assets/4eb820c5-a20e-4957-8611-aa72281373c5" />

---

## Tecnologias

- C# e .NET (aplicação de console)
- `HttpClient` e `System.Text.Json` para consumo da API
- `Microsoft.Extensions.DependencyInjection` e `Microsoft.Extensions.Http` para injeção de dependência

---

## Como executar

**Pré-requisito:** [.NET SDK](https://dotnet.microsoft.com/download) instalado (versão compatível com o `.csproj` do projeto).

```bash
git clone https://github.com/ejbussarello/ConsoleApi_RickMortyApi.git
cd ConsoleApi_RickMortyApi
dotnet run
```

Ao iniciar, use o menu:

<img width="300" height="180" alt="image" src="https://github.com/user-attachments/assets/37300113-91d7-4d74-9377-7d300c1eab90" />

Dentro de uma listagem:

<img width="418" height="64" alt="image" src="https://github.com/user-attachments/assets/12061569-21ff-4700-a6e0-20eb91b5e445" />

---

## Arquitetura

```
RickAndMortyApp/
├── Models/                  # Formato dos dados
│   ├── PageInfo.cs
│   ├── ApiResponse.cs
│   ├── LocationReference.cs
│   ├── Character.cs
│   ├── Location.cs
│   └── Episode.cs
├── Services/                # Comunicação com a API
│   ├── Interfaces/
│   │   └── IRickAndMortyService.cs
│   └── RickAndMortyService.cs
├── Views/                   # Exibição no console
│   ├── ConsoleHelper.cs
│   ├── MenuView.cs
│   ├── CharacterView.cs
│   ├── LocationView.cs
│   └── EpisodeView.cs
├── Controllers/             # Orquestração do fluxo
│   ├── ListControllerBase.cs
│   ├── MenuController.cs
│   ├── CharacterController.cs
│   ├── LocationController.cs
│   └── EpisodeController.cs
└── Program.cs               # Ponto de entrada e injeção de dependência
```

### Fluxo de uma requisição

```
Usuário escolhe uma opção
   → MenuController (decide o caminho)
   → CharacterController (pede os dados)
   → RickAndMortyService (HTTP + JSON → Models)
   → CharacterController (trata sucesso ou erro)
   → CharacterView (mostra na tela)
```

---

## Responsabilidade de cada camada

| Camada | Responsabilidade | Exemplos |
|---|---|---|
| **Models** | Descrevem o formato dos dados. Sem lógica, sem HTTP, sem console. | `Character`, `Location`, `Episode`, `ApiResponse<T>` |
| **Services** | Fazem as chamadas HTTP e convertem o JSON em Models. | `RickAndMortyService` |
| **Interfaces** | Definem o contrato do Service, desacoplando quem usa de quem implementa. | `IRickAndMortyService` |
| **Views** | Só exibem dados e leem a entrada do usuário. Não sabem de onde os dados vêm. | `CharacterView`, `MenuView`, `ConsoleHelper` |
| **Controllers** | Recebem a ação do usuário, pedem dados ao Service e entregam o resultado à View. | `MenuController`, `CharacterController` |
| **Program.cs** | Registra as dependências e inicia a aplicação (*composition root*). | `ServiceCollection` |

---

## Conceitos praticados

| Conceito | Onde aparece |
|---|---|
| **Separação de responsabilidades** | Cada camada tem um único papel |
| **Interfaces** | `IRickAndMortyService` permite trocar a implementação sem alterar os Controllers |
| **Injeção de dependência** | O container monta a cadeia de objetos a partir dos construtores |
| **Generics** | `ApiResponse<T>` e `ListControllerBase<T>` evitam código repetido |
| **async/await** | Chamadas HTTP sem travar o programa |
| **Classe abstrata (Template Method)** | `ListControllerBase<T>` define o loop de navegação; cada Controller informa só como buscar e exibir |
| **Tratamento de erros** | `null` para "sem resultados" (esperado) e exceções para falhas reais |
| **DRY** | Lógica repetida concentrada em um único lugar |

---

## Decisões de design

- **O Service não captura exceções.** Ele não sabe como avisar o usuário; essa decisão é do Controller.
- **404 não é erro.** A API responde 404 quando um filtro não encontra nada, e o Service trata isso como "sem resultados" (`null`).
- **Timeout de 10 segundos** para o usuário não ficar olhando uma tela parada.
- **Apenas os campos necessários são mapeados** nos Models; o restante do JSON é ignorado.

---

## Possíveis evoluções

- Detalhe de um personagem por ID
- Filtros extras (status, espécie, gênero)
- Cache de páginas já consultadas
- Testes unitários com um Service falso (`FakeRickAndMortyService`)

---

## Créditos

Dados fornecidos pela [Rick and Morty API](https://rickandmortyapi.com), gratuita e de uso aberto.
