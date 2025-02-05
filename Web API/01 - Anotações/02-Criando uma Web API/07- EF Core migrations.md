# O que é EF Core Migrations
O recurso Migrations no EF Core oferece uma maneira de atualizar de forma incremental o esquema de banco de dados para mantê-lo em sincronia com o modelo de dados do aplicativo, preservando os dados existentes no banco de dados.

Sempre que alterar as classes do modelo domínio, precisará executar o Migrations para manter o esquema do banco de dados atualizado.

# Comando para aplicar o Migrations usando EF Core Tools (Console)
Cria o script de migração
 - dotnet ef migrations add 'nome' 

Remove o script de migração criado
 - dotnet ef migrations remove 'nome'

Gera o banco de dados e as tabelas com base no script
 - dotnet ef database update

# Comandos para aplicar o Migrations (Package Manage Console)
Cria o script de migração
 - add-migration'nome'

Remove o script de migração criado
 - remove-migration'nome'
 
Gera o banco de dados e as tabelas com base no script
 - update-database