using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Customer.Api
{
    public static class App
    {
        public static void InitApp(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Test")
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
                    //c.SwaggerEndpoint("/swagger/v2/swagger.json", "Api v2");
                    c.DefaultModelsExpandDepth(-1);
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapHealthChecks("/Healthz/ready", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                Predicate = (check) => check.Tags.Contains("alive"),
            });

            app.MapHealthChecks("/Healthz/live", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                Predicate = _ => false
            });

            app.UseCors(app.Environment.EnvironmentName);

            app.Run();
        }
    }
}
