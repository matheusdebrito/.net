# Tipos de filtro
- Authorization: Determina se o usuário está autoriado no request atual. São executados primeiro.
- Resource: Podem executar código antes e depois do resto do filtro ser executado. Tratam do request após a autorização e executam antes do model binding ocorrer.
- Action: Executa o código imediatamente antes de depois do método Action do controlador ser chamado.
- Exception: São usados para manipular exceções ocorridas antes de qualquer coisa ser escrita no corpo da resposta.
- Result: Executam o código antes ou depois da execução dos resultados das Actions individuais do controlador.

# Implementação Síncrona
Os filtros síncronos que executam o código antes e depois do estágio do pipeline definem os métodos OnActionExecuting e OnActionExecuted
````c#
public class CustomActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Código: antes que a action executa
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Código: depois que a action executa
    }
}
````

# Implementação Assíncrona
Os filtros assíncronos herdam de IAsyncActionFilter e são definidos com um único método: OnActionExecuteAsync que usa um FilterTypeExecutingContext e o delegate FilterTypeExecutionDelegate para executar o estágio do pipeline do filtro.
````c#
public class CustomAsyncActionFilter :IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Código antes que a action executa
        await next();
        // Código depois que a action executa
    }
}
````

# Escopo e ordem de execução
Um filtro pode ser adicionado ao pipelina em um dos três escopos:
- Pelo método Action
- Pela classe do Controlador
- Globalmente (é aplicada a todos os controladores e actions)

A ordem padrão de execução é a seguinte:
- O filtro global é aplicado primeiro
- Depois o filtro de nível de classe é aplicado
- Finalmente, o filtro de nível de método é aplicado
