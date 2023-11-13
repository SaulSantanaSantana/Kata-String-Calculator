using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StringCalculator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();

//Dependency injector
var config = Setup.AppSetings(builder);
Setup.HistoryDependencyInjector(services, config);

Setup.addSwagger(services);

Setup.HistoryHealthChecks(builder, config);

var app = builder.Build();

Setup.MapHistoryHelathChecks(app);

Setup.ActivateSwagger(app);

app.UseAuthorization();

app.MapControllers();

Setup.CreateHistoryFile(config);

app.Run();