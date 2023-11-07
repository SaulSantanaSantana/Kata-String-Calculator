using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text;

namespace StringCalculator.HealthChecks
{

    public class StringCalculatorHistoryHealthCheck : IHealthCheck
    {

        private string path;

        public StringCalculatorHistoryHealthCheck(string path) {
            this.path = path;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = File.Exists(path);

            if (isHealthy)
            {
                return Task.FromResult(HealthCheckResult.Healthy("Healthy"));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("UnHealthy"));

        }
        
        public static Task writeResponse(HttpContext context, HealthReport healthReport)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions { Indented = true };

            using var memoryStream = new MemoryStream();
            using (var jsonWriter = new Utf8JsonWriter(memoryStream, options))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteString("status", healthReport.Status.ToString());
                jsonWriter.WriteStartObject("results");

                foreach (var healthReportEntry in healthReport.Entries)
                {
                    jsonWriter.WriteStartObject(healthReportEntry.Key);
                    jsonWriter.WriteString("status",
                        healthReportEntry.Value.Status.ToString());
                    jsonWriter.WriteString("description",
                        healthReportEntry.Value.Description);
                    jsonWriter.WriteStartObject("data");

                    foreach (var item in healthReportEntry.Value.Data)
                    {
                        jsonWriter.WritePropertyName(item.Key);

                        JsonSerializer.Serialize(jsonWriter, item.Value,
                            item.Value?.GetType() ?? typeof(object));
                    }

                    jsonWriter.WriteEndObject();
                    jsonWriter.WriteEndObject();
                }

                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndObject();
            }

            return context.Response.WriteAsync(
                Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

    }
}
