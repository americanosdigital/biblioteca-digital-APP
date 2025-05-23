using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using biblioteca_digital_Application.Interfaces;
using biblioteca_digital_Application.Services;
using biblioteca_digital_DOMAIN.Interfaces;
using biblioteca_digital_Infrastructure.Context;
using biblioteca_digital_Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Controladores e contexto do banco
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger com metadata
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Biblioteca Digital API",
        Version = "v1",
        Description = "API para gerenciamento de livros com .NET 9",
        Contact = new OpenApiContact
        {
            Name = "Wellington Americano",
            Email = "americanosdigital@gmail.com"
        }
    });
});

// Injeção de dependência
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();

// CORS para permitir acesso do frontend (ex: Angular)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://localhost:7219")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Scalar
app.MapScalarApiReference(
options => options.WithTheme(ScalarTheme.BluePlanet)
);

// Middleware padrão
app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();

// Mapear endpoints com controllers ou endpoints minimalistas
app.MapControllers();

app.Run();
