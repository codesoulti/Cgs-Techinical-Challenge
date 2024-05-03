namespace Cds.Technical.Challenge.Domain.NumberDecompositions
{
    public class NumberDecomposition
    {
        public long Number { get; set; }

        public NumberDecomposition() { }

        public NumberDecomposition(long number)
        {
            Number = number;
        }
    }
}
