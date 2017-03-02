using System;
using System.Collections.Generic;

public static class Exercism
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> sequence, Func<T, U> action)
    {
        foreach (var item in sequence)
        {
            yield return action(item);
        }
    }
}
