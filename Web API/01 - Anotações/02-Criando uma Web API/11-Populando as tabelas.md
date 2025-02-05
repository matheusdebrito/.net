# Popular tabelas com dados
 - Incluir dados manualmente usando INSERT INTO
 - Criar usar o método OnModelCreating do arquivo de contexto e definir o código usando a propriedade HasData do EF Core para preencher as tabelas com dados
 - Criar um método estático e definir o código para incluir dados usando o método AddRange() do EF Core
 - Crair uma migração vazia usando Migrations e usar os métodos Up() e Down() definindo nestes métodos as instruções INSERT INTO para incluir dados nas tabelas

# Popular a tabela Categorias com dados

1 - Criar uma nova migração usando Migrations: dotnet ef migrations add PopularCategorias

2 - Definir os comandos SQL no método Up() para incluir dados: insert into categorias(Nome,ImagemUrl) Values('Bebidas', 'bebidas.jpg)

3 - Definir os comandos SQL no método Down() para reverter a migração: delete from categorias

4 - Aplicar a migração: dotnet ef database update

Código do arquivo da migration PopulaCategorias
````c#
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Categorias(Nome, ImagemUrl) Values('Bebidas','bebidas.jpg')");
            mb.Sql("insert into Categorias(Nome, ImagemUrl) Values('Lanches','lanches.jpg')");
            mb.Sql("insert into Categorias(Nome, ImagemUrl) Values('Sobremesas','sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Categorias");
        }
    }
}
````

# Popular a tabela Produtos com dados

1 - Criar uma nova migração usando Migrations: dotnet ef migrations add PopularProdutos

2 - Definir os comandos SQL no método Up() para incluir dados: insert into produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) Values('Suco de laranja','Suco de laranja 500ml',7.45,'sucolaranja.jpg',10,now(), 1)

3 - Definir os comandos SQL no método Down() para reverter a migração: delete from produtos

4 - Aplicar a migração: dotnet ef database update

Código do arquivo da migration PopulaProdutos

````c#
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('Coca-Cola1','Refrigerante de cola 350ml',7.00,'cocacola.jpg',60,now(),1)");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('Lanche de atum','Lanche de atum com maionese',8.50,'atum.jpg',10,now(),2)");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('Pudim','Pudem de leite condensado 100g',6.75,'pudim.jpg',20,now(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("");
        }
    }
}
````