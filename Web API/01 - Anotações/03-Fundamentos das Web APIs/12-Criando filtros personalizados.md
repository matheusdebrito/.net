Além dos filtros padrões podemos criar nossos próprios filtros.
Na abordagem síncrona temos que criar uma classe que implementa a interface IActionFilter
Na abordagem assíncrona temos que criar uma classe que implementa a interface IAsyncActionFilter

Exemplo, criar um filtro personalizado que realiza o log de registros nos métodos Action dos nossos controladores. Usando a interface ILogger do namespace Microsoft.Extensions.Loggin que inclui métodos para realizar o log de registros.

Classe do logger 
````c#
using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogo.Filter
{
    public class ApiLogginFilter : IActionFilter
    {
        private readonly ILogger<ApiLogginFilter> _logger;

        public ApiLogginFilter(ILogger<ApiLogginFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Executa depois do action
            _logger.LogInformation("### Executando -> OnActionExecuted");
            _logger.LogInformation("###################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"Status Code: {context.HttpContext.Response.StatusCode}");
            _logger.LogInformation("###################################");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Executa antes do action
            _logger.LogInformation("### Executando -> OnActionExecuting");
            _logger.LogInformation("###################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
            _logger.LogInformation("###################################");
        }
    }
}
````

Registrar o serviço do filtro no container de injeção de dependência na classe Program
````c#
builder.Services.AddScoped<ApiLogginFilter>();
````

Aplicando o filtro a um método Action
````c#
// Aplica o filtro ApiLogginFilter
[ServiceFilter(typeof(ApiLogginFilter))]
````