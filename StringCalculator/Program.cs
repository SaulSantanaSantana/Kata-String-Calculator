using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StringCalculator.Persistance;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();

//Dependency injector
var config = builder.Configuration
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json",true,false)
    .Build();

services.AddSwaggerGen();
services.AddScoped<TimePicker, HistoryTimePicker>();
services.AddScoped<Save, HistoryStorer>(services => new HistoryStorer(config["HistoryPath"], services.GetService<TimePicker>()));
services.AddScoped<StringCalculatorHistoryHandler, StringCalculatorHistoryHandler>();

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