using System.Linq;

public static class Hamming
{
    public static int Compute(string sequence1, string sequence2)
    {
        return sequence1
                .ToCharArray()
                .Zip(sequence2.ToCharArray(), (l, r) => new { L = l, R = r })
                .Aggregate(0, (total, current) => total + (current.L == current.R ? 0 : 1));
    }
}