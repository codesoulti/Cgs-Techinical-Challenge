namespace Cds.Technical.Challenge.Application.Contracts.Mapper
{
    public interface IObjectMapper
    {
        TDestination Map<TSource, TDestination>(TSource sourceObject);
    }
}
