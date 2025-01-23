Template padrão: ASP.NET Core Web API

1 - Criar Web API com Controllers (CLI: dotnet new webapi -o NomeDoProjeto)
2 - Criar Web API sem Controllers: Minimal API (CLI: dotnet new webapi -minimal -o NomeDoProjeto)


Minimal API
Para criar uma Minimal API basta desmarcar a opção "Usar controladores" ao criar o projeto.

Em uma minimal API os endpoints são definidos diretamente no código da aplicação, geralmente no arquivo program.cs

````c#
var builder = WebAplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/bemvindo", () => "Bem Vindo à minha Minimal API!");
app.Run();
````

Isso é feito usando os métodos de extensão MapGet, MapPost, MapPut, MapDelete e outros disponíveis no objeto IApplicationBuilder.
Cada método corresponde a um verbo HTTP específico e permite que voce defina a lógica para lidar com as solicitações HTTP recebidas.