using Asp.Versioning;
using Cds.Technical.Challenge.Application;
using Cgs.Technical.Challenge.Application.NumberDecompositions.Validators;
using Cgs.Technical.Challenge.Domain.Shared.Http;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

namespace Cgs.Technical.Challenge.HttpApi.Host
{
    public static class Program
    {
        private async static Task<int> Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif

            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

            try
            {
                Log.Information("Starting Cgs.Technical.Challenge.HttpApi.Host.");
                var builder = WebApplication.CreateBuilder(args);
                builder.Host.UseSerilog();

                builder.Services.AddControllersWithViews();
                builder.Services.AddFluentValidationAutoValidation();
                builder.Services.AddFluentValidationClientsideAdapters();
                builder.Services.AddValidatorsFromAssemblyContaining<NumberDecompositionDtoValidator>();

                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen((options) =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Technical Challenge API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => $"{type.Namespace} {type.Name}");
                });

                builder.Services.AddHttpClient()
                    .AddApplication()
                    .AddApiVersioning(versioningOptions =>
                    {
                        versioningOptions.DefaultApiVersion = ApiVersion.Default;
                        versioningOptions.ReportApiVersions = true;
                        versioningOptions.AssumeDefaultVersionWhenUnspecified = true;
                    })
                    .AddApiExplorer(explorerOptions =>
                    {
                        explorerOptions.GroupNameFormat = "'v'VVV";
                        explorerOptions.SubstituteApiVersionInUrl = true;
                    });


                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();

                app.UseMiddleware<HttpResponseMiddlewareError>();
                app.UseMiddleware<HttpResponseMiddleware>();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

                await app.RunAsync();

                return 0;
            }
            catch (Exception ex)
            {
                if (ex is HostAbortedException)
                {
                    throw;
                }

                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}