O model binding ou vinculação de modelos é um recurso que nos permite mapear dados de uma requisição HTTP para os parâmetros de uma Action de um Controlador. Esse mapeamento inclui todos os tipos de parâmetros: números, string, arrays, listas, tipos complexos, listas de objetos, etc. Toda vez que implementamos Actions que recebem parâmetros estamos usando model binding

# Fontes de dados
1 - Valores de formulário: (POST e PUT) - Enviados no corpo do request

2 - Rotas: [Route("api/[Controller]")] ou HttpGet("{id}")

3 - Query Strings: api/produtos/4?nome=Suco&ativo=true

# Query Strings
Os valores são passados através da URL:
http://localhost:xxxx/produtos/4?nome=Suco&ativo=true
A query string inicia a partir da interrogação.

# Formulário

````c#
[HttpPost]
public ActionResult Post([FromBody]Produto produto){}

[HttpPut("{id}")]
public ActionResult Put(int id, [FromBody]Produto produto){}
````

# BindRequired
Atributo usado para indicar a obrigatoriedade de receber um parâmetro

````c#
[HttpGet("{id}")]
public async Task<ActionResult<Produto>> Get(int id, [BindRequired] string nome){}
````

# Atributos que indicam a fonte de dados
1 - FromForm: Utiliza somente dados do formulário enviado.
2 - FromRoute: Vincula apenas dados que são oriundos das rotas de dados.
3 - FromQuery: Recebe apenas os dados da cadeia de consulta (QueryString).
4 - FromHeader: Vincula os valores que vêm no cabeçalho da requisição HTTP.
5 - FromBody: Vincula os dados a partir do Body do request.
6 - FromServices: Vincula o valor espicificado à implementação que foi configurada no seu container de injeção de dependência.

````c#
[HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
// Recebe o id que foi passado através da QueryString
public async Task<ActionResult<Produto>> Get([FromQuery]int id)
{
    var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoID == id);
    if (produto is null)
    {
        return NotFound("Produto não encontrado");
    }
    return produto;
}
````