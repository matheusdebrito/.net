# Aplicando o Data Annotations na classe Categoria

````c#
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

// Faz com que a classe seja salva na tabela "Categorias"
[Table("Categorias")]
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    // Diz que essa variável será a chave no banco de dados
    [Key]
    public int CategoriaID { get; set; }
    // Diz que a variável é obrigatória
    [Required]
    // Diz que o tamanho da string no banco de dados é de 80 bytes
    [StringLength(80)]
    public string? Nome{ get; set; }
    // Diz que a variável é obrigatória
    [Required]
    // Diz que o tamanho da string no banco de dados é de 300 bytes
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public ICollection<Produto> Produtos { get; set; }
}
````

# Aplicando o Data Annotations na classe Produto

````c#
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

// Faz com que a classe seja salva na tabela "Categorias"
[Table("Produtos")]
public class Produto
{
    // Diz que essa variável será a chave no banco de dados
    [Key]
    public int ProdutoID { get; set; }
    // Diz que a variável é obrigatória
    [Required]
    // Diz que o tamanho da string no banco de dados é de 80 bytes
    [StringLength(80)]
    public string? Nome { get; set; }
    // Diz que o tamanho da string no banco de dados é de 300 bytes
    [StringLength(300)]
    public string? Descricao { get; set; }
    [Required]
    // Define que a precisão vai ser de 10 digitos e 2 casas decimais
    [Column(TypeName = "decimal(10,2)")]
    public decimal  Preco { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaID { get; set; }
    //Propriedade de navegação que indica que produto está mapeado para categoria
    public Categoria Categoria { get; set; }
}

````