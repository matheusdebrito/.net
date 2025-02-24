# Validação do modelo : Data Annotations
O namespace System.ComponentModel.DataAnnotations fornece classes de atributos que são usadas para realizar a validação dos dados. Os atributos Data Annotations permitem aplicar a validação no modelo de domínio definindo atributos. Os critérios de validação são definidos em um lugar (Model) e são aplicados onde o modelo for usado.

Quando os parâmetros do Model são usados nas Actions, ao popular o objeto do modelo usando os dados do request, o framework verifica se o objeto é válido com base nos atributos Data Annotations definidos nas propriedades do modelo.

# Principais atributos Data Annotations
- Required: Obriga a entrada de um campo específicado.
````c#
[Required]
public string Nome {get; set;}
````
Parâmetros - ErrorMessage
````c#
[Required(ErrorMessage="O nome do usuário é obrigatório")]
public string Nome {get; set;}
````

- RegularExpression: Permite usar expressões regulares em validações mais específicas
````C#
[Required(ErrorMessage = "Informe o seu email")]
[RegularExpression(".+\\@.+\\", ErrorMessage = "Informe um email válido...")]
public string Email {get; set;}
````

- StringLength: Determina o comprimento máximo e mínimo permitidos
````C#
[Required]
[StringLength(10, MinimumLength=4)]
public string Password {get; set;}
````
O parâmetro MinimumLength define a quantidade minima de caracteres permitida

- Range: Define um intervalo para uma propriedade onde a validação será aplicada
````C#
[Required]
[Range(18,65)]
public int idade {get; set;}

[Required]
[Range(18,65, ErrorMessage="A idade deve estar entre 18 e 65")]
public int idade {get; set;}
````

- CreditCard: Valida a entrada para o formato de um cartão de crédito
- Url: Define o formato exigido para uma Url
- Phone: Valida a entrada para o formato telefone
````C#
[CreditCard(ErrorMessage="mensagem")]
[Url]
[Phone]
public string Propriedade {get; set;}
````

- Compare: Permite comparar duas propriedades
````C#
[Compare("Senha")]
public string ConfirmaSenha {get; set;}
````