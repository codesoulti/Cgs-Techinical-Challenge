namespace technical.challenge.console
{
    using Cds.Technical.Challenge.Application.Contracts;
    using Cds.Technical.Challenge.Application.Contracts.Mapper;
    using Cds.Technical.Challenge.Domain.NumberDecompositions;
    using Cgs.Techinical.Challenge.Application.Mapper;
    using Cgs.Technical.Challenge.Application.NumberDecompositions;
    using Cgs.Technical.Challenge.Application.NumberDecompositions.Validators;
    using Cgs.Technical.Challenge.HttpApi.NumberDecompositions;
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Program
    {
        private static NumberDecompositionController controller;
        private static NumberDecompositionPrimeController controllerPrime;

        public static void Main(string[] args)
        {

            //services.AddTransient<IDivisorService, DivisorService>();


            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var numberDecopositonAppService = serviceProvider.GetService<INumberDecompositonAppService>();
            var numberDecopositonPrimeAppService = serviceProvider.GetService<INumberDecompositonPrimeAppService>();

            
            controller = new NumberDecompositionController(numberDecopositonAppService);
            controllerPrime = new NumberDecompositionPrimeController(numberDecopositonPrimeAppService);

            bool mostrarMenu = true;
            while (mostrarMenu)
            {
                mostrarMenu = Menu();
            }
        }


        public static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opçao:");
            Console.WriteLine("1 - Calcular");
            Console.WriteLine("3 - Sair");
            Console.Write("\r\nDigite o número da opçao desejada: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine($"\r\n'Calcular'");
                    CalcularDivisores(false);
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        public static string ObterEntradaUsuario()
        {
            Console.Write("\r\nDigite o número: ");
            return Console.ReadLine();
        }

        public static void Print(string mensagem)
        {
            Console.WriteLine($"\r\n{mensagem}");
            //Console.Write("\r\nPressione Enter para retornar ao menu principal: ");
            Console.ReadLine();
        }

        public static void CalcularDivisores(bool primo)
        {
            try
            {
                var entrada = ObterEntradaUsuario();
                if (!int.TryParse(entrada, out int number) || number <= 0)
                {
                    Print($"O valor digitado não é válido.");
                    return;
                }

                var input = new NumberDecompositionDto
                {
                    Number = number,
                };

                var result = controller.CalcularDecompostion(input);
                if (result.Any())
                {
                    var resultPrime = controllerPrime.CalcularDecompostionPrime(input);
                    Console.WriteLine($"Números divisores: {string.Join(" ", result)}");
                    Console.WriteLine($"Divisores primos: {string.Join(" ", resultPrime)}");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Print($"Ocorreu um erro: {ex.Message} ");
            }
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INumberDecompositonAppService, NumberDecompositonAppService>();
            services.AddScoped<INumberDecompositonPrimeAppService, NumberDecompositonPrimeAppService>();
            services.AddScoped<NumberDecompositionManager>();
            services.AddScoped<IValidator<NumberDecompositionDto>, NumberDecompositionDtoValidator>();
            services.AddTransient<IObjectMapper, ObjectMapper>();
        }
    };
}
