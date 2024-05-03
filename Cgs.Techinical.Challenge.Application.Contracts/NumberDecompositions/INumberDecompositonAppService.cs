namespace Cds.Technical.Challenge.Application.Contracts
{
    public interface INumberDecompositonAppService
    {
        List<long> CalcularDecompostion(NumberDecompositionDto input);
    }
}
