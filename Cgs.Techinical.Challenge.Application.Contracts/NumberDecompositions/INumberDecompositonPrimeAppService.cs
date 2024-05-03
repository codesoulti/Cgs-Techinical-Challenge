namespace Cds.Technical.Challenge.Application.Contracts
{
    public interface INumberDecompositonPrimeAppService
    {
        List<long> CalcularDecompostionPrime(NumberDecompositionDto input);
    }
}
