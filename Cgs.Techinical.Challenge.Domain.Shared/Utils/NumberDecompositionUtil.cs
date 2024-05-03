namespace Cgs.Techinical.Challenge.Domain.Shared.Utils
{
    public static class NumberDecompositionUtil
    {
        public static bool CheckNumberDivisor(long numero, long divisor)
        {
            if (numero % divisor == 0)
            {
                return true;
            }

            return false;
        }

        public static bool CheckNumberPrime(long number)
        {
            if (number <= 1 || (number % 2 == 0)) return false;
            if (number == 2) return true;
            

            var dividor = number / 2;
            for (var i = 2; i <= dividor; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
