using AutoMapper;
using Cds.Technical.Challenge.Application.Contracts;
using Cds.Technical.Challenge.Domain.NumberDecompositions;

namespace Cgs.Technical.Challenge.Application
{
    public class CgsApplicationAutoMapperProfile : Profile
    {
        public CgsApplicationAutoMapperProfile()
        {
            CreateMap<NumberDecompositionDto, NumberDecomposition>()
                .ReverseMap();
        }
    }
}
