using Cds.Technical.Challenge.Application.Contracts.Mapper;
using Cgs.Techinical.Challenge.Application.Mapper;

namespace Cgs.Technical.Challenge.Application
{
    public abstract class CgsBaseTest
    {
        protected IObjectMapper ObjectMapper { get; }
        protected CgsBaseTest()
        {
            ObjectMapper = new ObjectMapper();
        }
    }
}
