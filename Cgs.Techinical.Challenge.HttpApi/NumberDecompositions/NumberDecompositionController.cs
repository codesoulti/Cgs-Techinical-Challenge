using Asp.Versioning;
using Cds.Technical.Challenge.Application.Contracts;
using Cgs.Techinical.Challenge.Domain.Shared.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cgs.Technical.Challenge.HttpApi.NumberDecompositions
{
    public class NumberDecompositionController : CgsController, INumberDecompositonAppService
    {
        private readonly INumberDecompositonAppService _numberDecopositonAppService;

        public NumberDecompositionController(INumberDecompositonAppService numberDecopositonAppService)
        {
            _numberDecopositonAppService = numberDecopositonAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        [ProducesResponseType(typeof(HttpResponse<List<long>>), StatusCodes.Status200OK)]
        public List<long> CalcularDecompostion([FromQuery] NumberDecompositionDto input)
        {
            var result = _numberDecopositonAppService.CalcularDecompostion(input);
            return result;
        }
    }
}
