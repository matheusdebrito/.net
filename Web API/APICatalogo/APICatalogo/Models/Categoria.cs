using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

    [JsonIgnore]
    public ICollection<Produto>? Produtos { get; set; }
}
