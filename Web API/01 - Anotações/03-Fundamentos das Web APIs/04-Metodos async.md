O assincronimis é útil para melhorar a experiência do usuário quando há alguma operação que demanda muito tempo para ser executada.
O assincronimo não é grátis. Sempre que usa-lo há uma perda de desempenho, especialmente se usar thread. O ganho que ela dá é execução em paralelo, assim você pode atender mais requisições. A requisição específica não ficará mais rápida em hipótese alguma. Então tenha certeza que haverá algum ganho antes de usar este recurso.

````c#
[HttpGet]
public async Task<ActionResult<IEnumerable<Produto>>> Get()
{
    var produtos = _context.Produtos.AsNoTracking().ToListAsync();
    if (produtos is null)
    {
        return NotFound("Produtos não encontrados");
    }
    return await produtos;
}

[HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
public async Task<ActionResult<Produto>> Get(int id)
{
    var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoID == id);
    if (produto is null)
    {
        return NotFound("Produto não encontrado");
    }
    return produto;
}
````