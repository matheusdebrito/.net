Cria uma interface genérico contendo o contrato que define métodos genéricos que a classe concreta deverá implementar. Pode ser reutilizado com várias entidades ou tipos de dados sem ter que criar um repositório específico para cada entidade.

# Repositório genérico com abordagem híbrida:
Combinar repositórios genéricos para operações de acesso a dados comuns e repostórios específicos quando funcionalidades personalizadas são necessárias para entidades específicas.

As interfaces específicas herdam da interface genérica

# Interface genérica
````c#
using System.Linq.Expressions;

namespace APICatalogo.Repositories
{
    public interface IRepository<T>
    {
        // cuidado para não violar o princípio ISP
        IEnumerable<T> GetAll();
        T? Get(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}

````

# Classe genérica
````c#
using APICatalogo.Context;
using System.Linq.Expressions;

namespace APICatalogo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

````

# Interface específica
````c#
using APICatalogo.Models;

namespace APICatalogo.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
       
    }
}

````

# Classe específica
````c#
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}

````

# Controlador
````c#
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IRepository<Categoria> _repository;
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
            var categorias = _repository.GetAll();
            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _repository.Get(c=> c.CategoriaID == id);
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
            var categoria = _repository.Get(c=> c.CategoriaID == id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }

            var categoriaExcluida = _repository.Delete(categoria);

            return Ok(categoriaExcluida);
        }
    }
}
````

Para funcionar é preciso registrar o serviço na classe program
````c#
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
````

AddScoped não permite usar genérics por isso é preciso usar typeof()








