using BancoFondos.Application.Servicios;
using BancoFondos.Application.Interfaces;
using BancoFondos.EntityFramework.Db;
using BancoFondos.Core.Repositorios;
using Microsoft.EntityFrameworkCore;
using BancoFondos.EntityFramework.Fondos.Repositorios;
using BancoFondos.Core.DominioServicios.Interfaces;
using BancoFondos.Core.DominioServicios;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddScoped<IClienteAppService, ClienteAppService>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();



builder.Services.AddScoped<IFondoService, FondoAppService>();

builder.Services.AddScoped<IFondoDominioServicio, FondosDominioServicio>();

builder.Services.AddScoped<ITransaccionRepositorio, TransaccionRepositorio>();
builder.Services.AddScoped<IFondoRepositorio, FondoRepositorio>();








// Configurar la conexión a la base de datos (por ejemplo, SQL Server)
builder.Services.AddDbContext<BancoFondosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionBFDB")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
