# Restrições de rota
As restrições de rota nos ajudam a filtrar ou impedir que os valores indesejados atingam os métodos Action no controlador.
Isso é feito verificando a restrição com relação ao valor do parâmetro da URL.
````c#
// define que vai receber um valor inteiro pela URL e que esse valor precisa ser no mínimo 1
[HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
// só recebe valores alfanuméricos de A a Z maiúsculos ou minúsculos
[HttpGet("{valor:alpha}")]
// só recebe valores alfanuméricos de A a Z maiúsculos ou minúsculos com tamanho de 5 caracteres
[HttpGet("{valor:alpha:length(5)}")]
// só recebe valores alfanuméricos de A a Z maiúsculos ou minúsculos com tamanho máximo de 5 caracteres
[HttpGet("{valor:alpha:maxlength(5)}")]
````
Com restrições de rota podemos evitar consultas desnecessárias ao banco de dados.
As restrições de rota não devem ser usadas para validar as entradas. A validação deve ser feita no controlador. As restrições de rotas devem ser utilizadas para distinguir entre duas rotas parecidas.