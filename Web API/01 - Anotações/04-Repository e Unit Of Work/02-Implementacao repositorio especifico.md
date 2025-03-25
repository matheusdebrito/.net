- Criar a interface ICategoriaRepository
    - Definir o contrato para realizar as operações com Categorias
    - Definir assinaturas de métodos a serem implementados

- Criar a classe concreta CategoriaRepository
    - Fazer a implementação do contrato definido pala interface ICategoriaRespository
    - Implementar os métodos definidos

# Criar a interface ICateoriaRepository
Definir as assinaturas dos métodos com base nas operações que desejamos realizar com categorias
 - Obter as categorias a partir da fonte de dados
 - Obter uma única categoria com base em um critério (id)
 - Incluir uma nova categoria na fonte de dados
 - Alterar as informações de uma categoria existente na fonte de dados
 - Excluir uma categoria existente na fonte de dados

````c#
public interface ICategoriaRepository
{
    IEnumerable<Categoria> GetCategorias();
    Categoria GetCategoria(int id);
    Categoria Create(Categoria categoria);
    Categoria Update(Categoria categoria);
    Categoria Delete(int id);
}
````

# Classe concreta

````c#
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }
        public Categoria GetCategoria(int id)
        {
            return _context.Categorias.FirstOrDefault(c => c.CategoriaID == id);
        }
        public Categoria Create(Categoria categoria)
        {
            if (categoria is null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }
        
        public Categoria Update(Categoria categoria)
        {
            if (categoria is null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return categoria;
        }

        public Categoria Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria is null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }

        
    }
}
````

# Ajustando o controlador
````c#
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public CategoriasController(ICategoriaRepository respository, ILogger<CategoriasController> logger)
        {
            _repository = respository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _repository.GetCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _repository.GetCategoria(id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }
            return categoria;
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {

            if (categoria is null)
            {
                return BadRequest();
            }
            var categoriaCriada = _repository.Create(categoria);
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaCriada.CategoriaID}, categoriaCriada);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaID)
            {
                return BadRequest();
            }

            _repository.Update(categoria);
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _repository.GetCategoria(id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }

            var categoriaExcluida = _repository.Delete(id);

            return Ok(categoriaExcluida);
        }

    }


}
````

# Resgistrando o serviço do repositório na classe program
Para a injeção de dependência funcionar é preciso registrar o servidor na classe program

````c#
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
````