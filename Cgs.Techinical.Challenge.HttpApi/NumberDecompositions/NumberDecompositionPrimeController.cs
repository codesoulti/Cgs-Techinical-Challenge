using Asp.Versioning;
using Cds.Technical.Challenge.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Cgs.Technical.Challenge.HttpApi.NumberDecompositions
{
    [Route("api/app/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class NumberDecompositionPrimeController : CgsController, INumberDecompositonPrimeAppService
    {
        private readonly INumberDecompositonPrimeAppService _numberDecopositonPrimeAppService;

        public NumberDecompositionPrimeController(INumberDecompositonPrimeAppService numberDecopositonPrimeAppService)
        {
            _numberDecopositonPrimeAppService = numberDecopositonPrimeAppService;
        }

        [HttpGet]
        public List<long> CalcularDecompostionPrime([FromQuery] NumberDecompositionDto input)
        {
            return _numberDecopositonPrimeAppService.CalcularDecompostionPrime(input);
        }
    }
}
