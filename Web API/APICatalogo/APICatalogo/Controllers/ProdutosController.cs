using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        //private readonly IRepository<Produto> _repository;
        public ProdutosController(IProdutoRepository produtoRepository)
        {
            //_repository = repository;
            _produtoRepository = produtoRepository;
        }

        [HttpGet("produtos/{id}")]
        public ActionResult <IEnumerable<Produto>> GetProdutosCategoria(int id)
        {
            var produtos = _produtoRepository.GetProdutosPorCategoria(id);
            if (produtos is null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

        // Indica que é uma requisição GET
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _produtoRepository.GetAll();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }
            return Ok(produtos);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _produtoRepository.Get(c=> c.ProdutoID == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest();
            }
            var novoProduto = _produtoRepository.Create(produto);
            return new CreatedAtRouteResult("ObterProduto", new { id = novoProduto.ProdutoID }, novoProduto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoID)
            {
                return BadRequest();
            }

            var produtoAtualizado = _produtoRepository.Update(produto);

            return Ok(produtoAtualizado);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _produtoRepository.Get(p=> p.ProdutoID == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }

            _produtoRepository.Delete(produto);
            return Ok(produto);
            
        }

    }
}
