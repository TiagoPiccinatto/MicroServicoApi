using Catalogo.API;
using Catalogo.Domain.Interface;
using Catalogo.Domain.Service;
using Catalogo.Infra.Context;
using Catalogo.Infra.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "basic",
        Type = SecuritySchemeType.Http,
        Description = "basic Authentication using basic scheme"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "basic"
            }
        },
        new string[] {}
        }
        
    });
});
builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, Autenticacao>("BasicAuthentication", null);


builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddTransient<ProdutoService, ProdutoService>();



builder.Services.AddDbContext<CatalogoContext>(options =>
    options.UseSqlServer( b => b.MigrationsAssembly("Catalogo.API")));



var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

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
