# Métodos Action: Tipos de retorno
- Tipo Específico: Retorna um tipo de dados complexo ou primitivo (string, int, etc)
````c#
[HttpGet]
public string Get(){
    return "retornando string";
}
````
- IActionResult: É apropriado quando vários tipos de retorno ActionResult são possíveis em métodos Action.
````c#
[HttpGet]
public IActionResult Get(){
    var produto = _context.Produtos.FirstOrDefault();
    if (produto == null){
        return NotFound();
    }
    return Ok(produto);
}
````
- ActionResult<T>: Permite o retorno de um tipo derivado de ActionResult ou o retorno de um tipo específico <T>
````c#
[HttpGet]
public ActionResult<Produto> Get(){
    var produto = _context.Produtos.FirstOrDefault();
    if (produto == null){
        return NotFound();
    }
    return produto;
}
````

