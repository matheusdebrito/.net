Definir o relacionamento um-para-muitos nas entidades Categoria e Produto.
A forma mais simples de definir um relacionamento entre entidades é usar as convenções do EF Core.
Usar propriedades de navegação para indicar ao EF Core o relacionamento entre as entidades

````c#
using System.Collections.ObjectModel;

namespace APICatalogo.Models;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    public int CategoriaID { get; set; }
    public string? Nome{ get; set; }
    public string? ImagemUrl { get; set; }
    public ICollection<Produto> Produtos { get; set; }
}

````
Adicionamos o código public ICollection<Produto> Produtos { get; set; } na classe categoria. Esse código indica que a classe Categoria pode ter vários produtos.

Além disso precisamos adicionar o código public int CategoriaID { get; set; } na classe Produto.

````c#

````