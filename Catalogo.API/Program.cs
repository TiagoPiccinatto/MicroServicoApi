using Catalogo.Domain.Interface;
using Catalogo.Domain.Service;
using Catalogo.Infra.Context;
using Catalogo.Infra.Repositorio;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddTransient<ProdutoService, ProdutoService>();



builder.Services.AddDbContext<CatalogoContext>(options =>
    options.UseSqlServer( b => b.MigrationsAssembly("Catalogo.API")));



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
