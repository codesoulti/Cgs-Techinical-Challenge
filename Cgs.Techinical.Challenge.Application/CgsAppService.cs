using Cds.Technical.Challenge.Application.Contracts.Mapper;

namespace Cgs.Technical.Challenge.Application
{
    public abstract class CgsAppService
    {
        protected readonly IObjectMapper _mapper;

        protected CgsAppService()
        {
        }

        protected CgsAppService(IObjectMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
