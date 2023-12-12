using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Core;
using TaxCalculator.DB;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Core.CalculationManagement.Service.Calculator;
using TaxCalculator.Core.CalculationManagement.Service.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatRScanPin).Assembly));

builder.Services.AddDbContext<TaxCalculatorDbContext>(
     options => options.UseSqlServer("name=ConnectionStrings:TaxCalculatorDB"));

builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
