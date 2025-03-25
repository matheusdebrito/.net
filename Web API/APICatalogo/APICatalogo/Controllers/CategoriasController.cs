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
