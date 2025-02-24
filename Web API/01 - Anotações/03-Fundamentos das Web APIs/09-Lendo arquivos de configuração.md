# Lendo arquivos de configuração
Uma das formar de fazer isso é usando o serviço disponível pela interface IConfiguration através da injeção de dependência para obter o serviço IConfiguration configurado por padrão.
````c#
private readonly IConfiguration _configuration;
public Construtor(IConfiguration config)
{
    _configuration = config;
}

var valor1 = _configuration["chave"];
var valor2 = _configuration["seção:chave"];
````

# Usando dados do arquivo de configuração

Inserindo dados no arquivo de configuração 
````c#
{
  "chave1": "valor1",
  "chave2": 1000,
  "secao1": {
    "chave1": "valor da chave 1 na secao 1",
    "chave2": "valor da chave 1 na secao 2"
  }
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;DataBase=CatalogoDB;UiD=root;Pwd='P@$$w0rd18059104';"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
````

Criando uma rota para ler os dados no controlador
````c#
using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public CategoriasController(AppDbContext context, IMeuServico meuServico, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("LerArquivoConfiguracao")]
        public string GetValores()
        {
            var valor1 = _configuration["chave1"];
            var valor2 = _configuration["chave2"];

            var secao1 = _configuration["secao1:chave2"];

            return $"Chave 1 = {valor1} \nChave 2 = {valor2} \nSeção 1 = {secao1}";

        }
    }
}
````

Lendo as informações através da classe Program
````c#
var valor1 = builder.Configuration["chave1"];
var valor2 = builder.Configuration["chave2"];
````