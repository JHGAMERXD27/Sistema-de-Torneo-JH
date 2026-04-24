using Microsoft.EntityFrameworkCore;
using SistemaTorneos.Core.Interfaces;
using SistemaTorneos.Infrastructure.Data;
using SistemaTorneos.Infrastructure.Repositories;
using SistemaTorneos.Application.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TorneoDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IJugadorRepository, JugadorRepository>();
builder.Services.AddScoped<TorneoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ---> ESTAS DOS LÍNEAS ACTIVAN EL FRONTEND EN wwwroot <---
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();