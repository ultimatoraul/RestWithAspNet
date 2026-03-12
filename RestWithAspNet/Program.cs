using RestWithAspNet.Domain.Interfaces;
using RestWithAspNet.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Para o MathService é necessário:
//Criar uma única instância do serviço para toda a aplicação, ou seja, o mesmo serviço é compartilhado entre todas as requisições e usuários.
//Ele é ideal para serviços que não mantêm estado ou que precisam ser compartilhados, como serviços de configuração ou serviços de cache.
builder.Services.AddSingleton<IMathService, MathService>();

//Para o PersonService é necessário: 
//Recriar o escopo a cada requisição, ou seja, a cada requisição um novo serviço é criado.
//Ele é ideal para serviços que precisam manter estado durante uma única requisição, como serviços de negócios ou repositórios de dados.
builder.Services.AddScoped<IPersonService, PersonService>(); 
                                                             
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
