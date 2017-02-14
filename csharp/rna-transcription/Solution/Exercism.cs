using System;
using System.Text;

public static class Complement
{
    public static string OfDna(string strand)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char n in strand)
        {
            switch (n)
            {
                case 'G':
                    sb.Append('C');
                    break;
                case 'C':
                    sb.Append('G');
                    break;
                case 'T':
                    sb.Append('A');
                    break;
                case 'A':
                    sb.Append('U');
                    break;
                default:
                    throw new ArgumentException($"The nucleotide {n} is unknown and cannot be mapped.");
            }

        }
        return sb.ToString();
    }
}
