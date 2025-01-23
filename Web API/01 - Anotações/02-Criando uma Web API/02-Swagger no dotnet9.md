Aplicações na versão 9 do dotnet não usam o Swagger de maneira automática.
Para usar o Swagger temos que incluir o pacote Swashbuckle.AspNetCore.SwaggerUI:
 - Clicar com botão direito no nome do projeto
 - Clicar me gerenciar pacotes do nuget
 - Pesquisar pelo pacote "Swashbuckle.AspNetCore.SwaggerUI" e instalar
 - ir para a classe program e procurar o bloco if que verifica se está em um ambiente de desenvolvimento e adicionar o código:
````c#
app.SwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "weather api"));
````
 - Ir até o arquivo launchSettings.json e no perfil https definir "launchBrowser": true e "launchUrl": "swagger"

