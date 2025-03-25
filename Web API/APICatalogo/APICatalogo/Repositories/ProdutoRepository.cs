using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace APICatalogo.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Produto> GetProdutosPorCategoria(int id)
        {
            return GetAll().Where(c=> c.CategoriaID == id);
        }
    }            
}
