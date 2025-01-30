# Usar o EF Core na abordagem Code-First
Podemos realizar o mapeamento das classes das entidades do domínio e gerar o banco de dados e as tabelas.
Primeiro criamos as entidades e a partir delas geramos o banco de dados e as tabelas.
O EF Core adota algumas convenções para realizar o mapeamento das entidades.

Incluir referências ao EF Core e ao provedor Pomelo para o MySQL.
 - Clicar em ferramentas > Gerenciador de pacotes do NuGet > Gerenciar pacotes do NuGet para a solução
 - Instalar o pacote Pomelo.EntityFrameworkCore.MySql
 - Instalar o pacote MicrosoftEntityFrameworkCore.Design
 - Instalar o DotNet EF (na máquina e não no projeto): dotnet tool install --global dotnet-ef
