using Microsoft.EntityFrameworkCore;
using PositionsServiceAPI.Application.Services;
using PositionsServiceAPI.Domain.Interfaces;
using PositionsServiceAPI.Infrastructure.Data;
using PositionsServiceAPI.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PositionsServiceDbContext>(options =>
												options.UseSqlServer(builder.Configuration.GetConnectionString("PositionsServiceDbContext") ?? throw new InvalidOperationException("Connection string 'PositionsServiceDbContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IPositionsRepository, PositionsRepository>();
// Register services
builder.Services.AddScoped<PositionsServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
