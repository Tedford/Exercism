using System;
using System.Linq;

public static class Grains
{
    public static double Square(int number) => Math.Pow(2, number - 1);

    public static double Total() => Enumerable.Range(1, 64).Sum(i => Square(i));
}

