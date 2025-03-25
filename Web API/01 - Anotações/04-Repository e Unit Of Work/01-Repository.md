# O que é o padrão repository
Pela definição de Martin Fowler "O padrão repository faz a medição entre o domínio e as camadas de mapeamento de dados, agindo como uma coleção de objetos de domínio em memória..."

# Benefícios
- Minimiza a lógica de consultas na sua aplicação evitando consultas esparramadas pelo seu código(encapsula a lógica das consultas no repositório).
- Desacopla a sua aplicação dos frameworks de persistência como Entity Framework.
- Facilita a realização de testes unitários em seu projeto(usando um repositório fake).

# Implementação
Criar uma interface onde definimos o contrato que representa os métodos que deverão ser implementados por uma classe concreta

Interface (Define o contrato) -----> Classe concreta(Implementa o contrato da interface)

Registrar no container de injeção de dependências(DI) as classes concretas que implementam as interfaces como serviços disponíveis:
````c#
builder.service.AddScoped<Interface, Class_Concreta>();
````

# Implementação com repositório específico
Cria uma interface para uma entidade específica contendo os contrato que define os métodos que a classe concreta deverá implementar.

Interface
````c#
public interface ICategoriaRepository
{
    IEnumerable<Categoria> GetCategorias();
    Categoria GetCategoria(int id);
    void Add(Categoria categoria);
    void Update(Categoria categoria);
    void Delete(int id);
}
````
Classe concreta
````c#
public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    // Implementação dos métodos da interface
}
````

# Implementação com repositório genérico
Cria uma interface genérica contendo o contrato que define métodos genéricos que a classe concreta deverá implementar.

Interface genérica
````c#
public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T Get(int id);
    T Add(T entity);
    T Update(T entity);
    void Delete(int id);
}
````

Classe concreta
````c#
public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    // Implementação dos métodos da interface
}
````