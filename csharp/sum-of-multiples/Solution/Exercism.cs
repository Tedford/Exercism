using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    private static bool IsMultiple(int candidate, int number) => candidate % number == 0;

    public static int To(IEnumerable<int> factors, int value)
    {
        return Enumerable.Range(1, value-1)
        .Where(i => factors.Any(f => IsMultiple(i, f)))
        .Sum();
    }
}

