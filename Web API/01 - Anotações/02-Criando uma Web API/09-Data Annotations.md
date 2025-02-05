# Data Annotations
São um conjunto de atributos que podem ser aplicados a classes e seus membros para fornecer metadados sobre como esses recursos devem ser tratados pelo sistema. São usado para:
 - Realizar validações de entrada de dados
 - Influenciar o comportamento do modelo de dados

O EF Core usa um conjunto de regras(convenção padrão) para criar e atualizar as tabelas e o esquema do banco de dados quando as migrações são aplicadas. Exemplo: Para o MySQL o tipo string é mapeado para o tipo longtext e o tipo decimal usa uma precisão de 65 dígitos com 30 casas decimais.

Os atributos data annotations podem sobrescrever as convenções usadas pelo EF Core.

# Data Annotations para sobrescrever as convenções do EF Core
 - Key: Identifica a propriedade como uma chave primaria na tabela
 - Table("nome"): Define o nome da tabela para qual a classe será mapeada
 - Column: Define a coluna na tabela para qual a classe será mapeada
 - DateType: Associa um tipo de dados adicional a uma propriedade
 - ForeignKey: Especifica que a propriedade é usada como chave estrangeira
 - NotMapped: Exclui a propriedade do mapeamento
 - StringLength: Define o tamanho mínimo e máximo permitido para o tipo
 - Required: Especifica que o valor do campo é obrigatório(NOT NULL)