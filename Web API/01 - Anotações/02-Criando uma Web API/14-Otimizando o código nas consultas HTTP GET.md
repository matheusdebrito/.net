# Otimizando o código nas consultas com HTTP GET
Quando consultamos entidades usando o entity framerwork ele armazena as entidades no contexto (em cache) realizando o tracking ou rastreamento das entidades para acompanhar o estado das entidades.
Este recurso adiciona uma sobrecarga que afeta o desempenho das consultas rastreadas.
Para melhorar o desempenho podemos usar o método: AsNoTracking().
````c#
var produtos = _context.Produtos.AsNoTracking().ToList();
````
Usar AsNoTracking() apenas para consultas somente leitura sem a necessidade de alterar os dados.

# Otimizando o desempenho
Nunca retorne todos os registros em uma consulta.
````c#
_context.Produtos.Take(10).ToList();
````

Nunca retorne objetos relacionados sem aplicar um filtro
````c#
_context.Categorias.Include(p=>p.Produtos).Where(c=>c.CategoriaId <= 5).ToList();
````