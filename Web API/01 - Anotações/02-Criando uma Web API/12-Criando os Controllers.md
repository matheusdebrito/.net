# Controllers
Os controladores são arquivos armazenados dentro da pasta Controllers criada na raiz de uma aplicação ASP.NET Core Web API usando o template de projeto padrão
Os Controllers em uma Web API são classes que derivam da classe ControllerBase
O nome de um Controller é formado pelo nome do controlador seguido pelo sufixo Controller. Ex: CategoriasCotroller, ProdutosController
Estrutura básica de um controlador:

````c#
[Route("[controller]")]
[ApiController]
public class TesteController : ControllerBase
{
    // métodos Action
}
````

A classe ControllerBase fornece muitas propriedades e métodos que são úteis para lidar com requisições HTTP. Ex:
BadRequest(): Retorna status code 400
NotFound(): Retorna status code 404
CreatedAtAtion(): Retorna status code 201
PhysicalFile(): Retorna um arquivo
TryValidationModel(): Invoca a validação do modelo
Ok(): Retorna status code 200

# ApiController
O atributo [ApiController] permite decorar os controladores habilitando recursos como:
 - Requisito de roteamento de atributo;
 - Respostas HTTP 400 automáticas (Validação model state);
 - Inferência de parâmetro de origem de associação;
 - Inferência de solicitação de dados de várias partes/formulário;
 - Uso de Problem Details para códigos de status de erro

# Route
O atributo [Route] especifica um padrão de URL para acessar um controller ou Action. [Route("[controller]")] -> indica a rota com o nome do controlador