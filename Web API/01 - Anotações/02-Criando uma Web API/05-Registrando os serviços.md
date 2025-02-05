Precisamos informar qual a string de conexão. Vamos inserir no arquivo appsettings.json
Vamos incluir um sessão:
````c#
"ConnectionStrings":{
    "DefaultConnection":"Server=localhost;DataBase=CatalogoDB;UiD=root;Pwd=P@$$w0rd18059104"
},
````
Após isso podemos registrar o contexto do EF Core como um serviço e configurar o contexto.
Incluir um código na classe Program abaixo de builder
````c#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Código para registrar o EF Core
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection,
        ServerVersion.AutoDetect(mySqlConnection)));
````