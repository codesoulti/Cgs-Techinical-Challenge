using Cds.Technical.Challenge.Application.Contracts;
using Cds.Technical.Challenge.Application.Contracts.Mapper;
using Cds.Technical.Challenge.Domain.NumberDecompositions;
using Cgs.Techinical.Challenge.Application.Mapper;
using Cgs.Technical.Challenge.Application.NumberDecompositions;
using Cgs.Technical.Challenge.Application.NumberDecompositions.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cds.Technical.Challenge.Application
{
    public static class CgsApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
             .AddScoped<INumberDecompositonAppService, NumberDecompositonAppService>()
             .AddScoped<INumberDecompositonPrimeAppService, NumberDecompositonPrimeAppService>()
             .AddScoped<NumberDecompositionManager>()
             .AddScoped<IValidator<NumberDecompositionDto>, NumberDecompositionDtoValidator>()
             .AddTransient<IObjectMapper, ObjectMapper>();
        }
    }
}
