1 - Criar atributos customizados:
 - O seu foco é validar uma propriedade.
 - Pode ser reutilizada em diversos modelos e propriedades

2 - Implementar IValidadeObject no seu modelo
 - Pode acessar todas as propriedades do modelo e realizar uma validação mais complexa.
 - Não pode ser reutilizada em outros modelos.

Criar uma pasta Validation
Criar uma classe com o nome da validação e Attribute no final
Usar [NomeDaValidacao] na variável no arquivo na pasta model

Classe PrimeiraLetraMaiusculaAttribute
````C#
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Validation
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var primeiraLetra = value.ToString()[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                return new ValidationResult("A primeira letra do nome do produto deve ser máiúscula");
            }

            return ValidationResult.Success;
        }
    }
}

````

Model Produto
````C#
using APICatalogo.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    // Usa a validation para verificar se a primeira letra é maiúscula
    [PrimeiraLetraMaiuscula]
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
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
}

````
