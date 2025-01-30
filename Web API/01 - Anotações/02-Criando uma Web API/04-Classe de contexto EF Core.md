É nesta classe que definimos o mapeamento entre as entidades e as tabelas.

````c#
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {}

    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Produto> Produtos {get; set;}
} 
````

DbContext - Representa uma sessão com o banco de dados sendo a ponte entre as entidades de domínio e o banco
DbSet - Representa uma coleção de entidades no contexto que podem ser consultadas no banco de dados