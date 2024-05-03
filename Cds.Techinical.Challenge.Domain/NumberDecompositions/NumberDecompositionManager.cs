using Cgs.Techinical.Challenge.Domain.Shared.Utils;

namespace Cds.Technical.Challenge.Domain.NumberDecompositions
{
    public class NumberDecompositionManager
    {
        public NumberDecompositionManager()
        { }

        public virtual List<long> CalcularDecompostion(NumberDecomposition input)
        {
            var numbers = new List<long>();

            for (long i = 1; i <= input.Number; i++)
            {
                if (NumberDecompositionUtil.CheckNumberDivisor(input.Number, i))
                {
                    numbers.Add(i);
                }
            }

            return numbers;
        }

        public virtual List<long> CalcularDecompostionPrime(NumberDecomposition input)
        {
            var numbers = CalcularDecompostion(input);

            return numbers
                .Where(NumberDecompositionUtil.CheckNumberPrime)
                .ToList();
        }
    }
}
