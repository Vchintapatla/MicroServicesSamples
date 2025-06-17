using Microsoft.EntityFrameworkCore;

using RatesServiceAPI.Application.Services;
using RatesServiceAPI.Domain.Interfaces;
using RatesServiceAPI.Infrastrucutre.Data;
using RatesServiceAPI.Infrastrucutre.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ExchangeRatesDbContext>(options =>
											options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register repositories
builder.Services.AddScoped<IExchangeRatesRepo, ExchangeRatesRepo>();
// Register services
builder.Services.AddScoped<ExchangeRatesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
