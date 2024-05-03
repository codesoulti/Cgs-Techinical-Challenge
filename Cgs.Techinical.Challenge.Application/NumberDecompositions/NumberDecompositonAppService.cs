using Cds.Technical.Challenge.Application.Contracts;
using Cds.Technical.Challenge.Application.Contracts.Mapper;
using Cds.Technical.Challenge.Domain.NumberDecompositions;

namespace Cgs.Technical.Challenge.Application.NumberDecompositions
{
    public class NumberDecompositonAppService : CgsAppService, INumberDecompositonAppService
    {
        private readonly NumberDecompositionManager _numberDecopositonManager;

        public NumberDecompositonAppService(
            NumberDecompositionManager numberDecopositonManager,
            IObjectMapper mapper
        ) : base(mapper)
        {
            _numberDecopositonManager = numberDecopositonManager;
            
        }
        public List<long> CalcularDecompostion(NumberDecompositionDto input)
        {
            var numberDecomposition = _mapper.Map<NumberDecompositionDto, NumberDecomposition>(input);

            return _numberDecopositonManager.CalcularDecompostion(numberDecomposition);
        }
    }
}
