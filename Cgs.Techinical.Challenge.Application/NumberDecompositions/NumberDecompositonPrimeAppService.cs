using Cds.Technical.Challenge.Application.Contracts;
using Cds.Technical.Challenge.Application.Contracts.Mapper;
using Cds.Technical.Challenge.Domain.NumberDecompositions;

namespace Cgs.Technical.Challenge.Application.NumberDecompositions
{
    public class NumberDecompositonPrimeAppService : CgsAppService, INumberDecompositonPrimeAppService
    {
        private readonly NumberDecompositionManager _numberDecopositonManager;

        public NumberDecompositonPrimeAppService(
            NumberDecompositionManager numberDecopositonManager,
            IObjectMapper mapper
        ) : base(mapper)
        {
            _numberDecopositonManager = numberDecopositonManager;
        }
        
        public List<long> CalcularDecompostionPrime(NumberDecompositionDto input)
        {
            var map = _mapper.Map<NumberDecompositionDto, NumberDecomposition>(input);

            return _numberDecopositonManager.CalcularDecompostionPrime(map);
        }
    }
}
