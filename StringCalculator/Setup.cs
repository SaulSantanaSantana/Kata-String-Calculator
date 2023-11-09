﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StringCalculator.Persistance;
using StringCalculator.HealthChecks;
using System;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace StringCalculator
{
    public static class Setup
    {
        public static IConfigurationRoot AppSetings(WebApplicationBuilder builder) {

            return builder.Configuration
                   .SetBasePath(Environment.CurrentDirectory)
                   .AddJsonFile("appsettings.json", true, false)
                   .Build(); ;
        }

        public static void HistoryDependencyInjector(IServiceCollection services, IConfigurationRoot config)
        {
            services.AddScoped<TimePicker, HistoryTimePicker>();
            services.AddScoped<Save, HistoryStorer>(services => new HistoryStorer(config["HistoryPath"], services.GetService<TimePicker>()));
            services.AddScoped<StringCalculatorHistoryHandler, StringCalculatorHistoryHandler>();
        }

        public static void HistoryHealthChecks(WebApplicationBuilder builder, IConfigurationRoot config) {
            var fullPath = Environment.CurrentDirectory + @"\\" + config["HistoryPath"];
            builder.Services.AddHealthChecks().AddCheck("HistoryCheck", new StringCalculatorHistoryHealthCheck(fullPath));
        }

        internal static void MapHistoryHelathChecks(WebApplication app)
        {
            app.MapHealthChecks("/status.json", new HealthCheckOptions
            {
                ResponseWriter = StringCalculatorHistoryHealthCheck.writeResponse
            }).RequireHost("*:7049");
        }
    }
}
