using webapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); // se crea una nueva instacia de la dependecia que estamos usando a nivel clase
                            // add singleton unica instacia a nivel api no es recomendable
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService()); // no es buena practica 

// configuracion de inyeccion de dependencias 
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
// aqui van los custom  middlewares
//app.UseWelcomePage(); // custom middleware de pagina de bienvenida.
// ------------ estre estos dos 

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
