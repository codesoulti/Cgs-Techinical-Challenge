using Cds.Technical.Challenge.Application.Contracts.Mapper;
using Cgs.Techinical.Challenge.Application.Mapper;

namespace Cgs.Technical.Challenge.Application
{
    public abstract class CgsAppServiceTest
    {
        protected IObjectMapper ObjectMapper { get; }
        protected CgsAppServiceTest()
        {
            ObjectMapper = new ObjectMapper();
        }
    }
}
