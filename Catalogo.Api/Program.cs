using Catalogo.Aplicacion.Repositorios;
using Catalogo.Aplicacion.Servicios;
using Catalogo.Infraestructura.Repositorios;
using Catalogo.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Registrar el DbContext
builder.Services.AddDbContext<CatalogoDbContext>(options =>
    options.UseSqlServer(connectionString));

//Registrar los repositorios
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

//Registrar los servicios
builder.Services.AddScoped<ProductoServicio>();
builder.Services.AddScoped<CategoriaServicio>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
