# Roteamento
Roteamento é o mapeamento dos endpoints. Em uma aplicação podemos ter mais de uma requisição GET e para diferenciar as duas usamos o roteamento. Abaixo exemplo de duas requisições GET. Sem esse roteamento os dois métodos GET atenderiam a url api/produtos com esse roteamento definimos que a função GetPrimeiro() atende a url api/produtos/primeiro.

````c#
// define que a url é api/produtos/primeiro
[HttpGet("primeiro")]
public ActionResult<Produto> GetPrimeiro()
{
    var produto = _context.Produtos.FirstOrDefault();
    if (produto is null)
    {
        return NotFound("Produto não encontrado");
    }
    return produto;
}


// Indica que é uma requisição GET
[HttpGet]
public ActionResult<IEnumerable<Produto>> Get()
{
    var produtos = _context.Produtos.AsNoTracking().ToList();
    if (produtos is null)
    {
        return NotFound("Produtos não encontrados");
    }
    return produtos;
}
````
podemos também ignorar o nome do controller para acessar um método apenas colocando uma barra. Por exemplo
````c#
// define que a url é api/primeiro
[HttpGet("/primeiro")]
public ActionResult<Produto> GetPrimeiro()
{
    var produto = _context.Produtos.FirstOrDefault();
    if (produto is null)
    {
        return NotFound("Produto não encontrado");
    }
    return produto;
}
````

Para passar dois parâmetros pela url

````c#
[HttpGet("{id: int}/{param2}")]
// atribui valor ao segundo parâmetro
[HttpGet("{id: int}/{param2=Teste}")]
````

Também é possível passar mais de uma rota para uma mesma função
````c#
[HttpGet("/primeiro")]
[HttpGet("teste")]
[HttpGet("primeiro")]
public ActionResult<Produto> GetPrimeiro()
{
    var produto = _context.Produtos.FirstOrDefault();
    if (produto is null)
    {
        return NotFound("Produto não encontrado");
    }
    return produto;
}
````