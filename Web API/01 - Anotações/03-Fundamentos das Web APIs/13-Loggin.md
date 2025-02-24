# Interfaces de Microsoft.Extensions.Logging
- ILogginFactory: É uma factory interface para criar uma instância apropriada do tipo ILoger e também para adicionar uma instância ILoggerProvider.
- ILogginProvider: Gerencia e cria o registrador apropriado especificado pela categoria de registro. 
- Ilogger: Inclui método para loggin de registros subjacentes.

Configuração de loggin no arquivo appsettings.Development.json
````c#
{
    "Loggin":{
        "LogLevel":{
            "Default": "Debug",
            "System": "Information",
            "Microsoft": "Information",
        },
        "Console":{
            "IncludeScopes": true
        }
    }
}
````

Criando o logger
No controlador
````c#

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        // variavel privada para fazer injeção de dependencia
        private readonly ILogger _logger;

        public CategoriasController(AppDbContext context, IMeuServico meuServico, IConfiguration configuration, ILogger<CategoriasController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // usando o logger no método Action
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            _logger.LogInformation("==========GET api/categorias/produtos============");
            return _context.Categorias.Include(p => p.Produtos).ToList();
        }


````