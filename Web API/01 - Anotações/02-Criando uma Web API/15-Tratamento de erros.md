# Tratamento de erros: Ambiente de desenvolvimento
Usa por padrão a página de exceção do desenvolvedor que exibe informações detalhadas sobre as exceções como:
 - Stack Trace (Rastreamento de pilha)
 - Parâmetros de cadeia de caractere de consulta
 - Cookies
 - Headers (Cabeçalhos)

As informações de exceção detalhadas não devem ser exibidas quando o aplicativo for executado no ambiente de produção.

# Tratamento de erros: Ambiente de produção
Para configurar uma página de tratamento de erros personalizada para o ambiente de produção usamos middlewares UseExceptionHandler
 - Captura e registra exceções não tratadas
 - Executa novamente o request em um pipeline alternativo usando o caminho indicado (quando o response não foi iniciado). O código gerado executa o request usando o caminho /Error.

 ````c#
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
 ````

# Try Catch

````c#
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            try
            {
                if (id != produto.ProdutoID)
                {
                    return BadRequest();
                }

                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }
````