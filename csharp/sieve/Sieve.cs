using System;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        var sieve = Enumerable.Repeat(true, Math.Max(3,limit)).ToArray();

        sieve[0] = false;
        sieve[1] = false;

        for (int i = 0; i < sieve.Length; i++)
        {
            for (int j = i * i, ith = 0; j < limit && sieve[i]; j = i * i + i * ith, ith++)
            {
                sieve[j] = false;
            }
        }

        return sieve.Select((v,i)=> new { Index = i, Value=v })
                    .Where(i => i.Value)
                    .Select(i=>i.Index)
                    .ToArray();
    }
}