using System;
using System.Linq;

public class Squares
{
    public int Value { get; }

    public Squares(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value),"A value of 0 or greater must be supplied.");
        }
        Value = value;
    }

    public int SquareOfSums() =>(int)Math.Pow(Enumerable.Range(1, Value).Sum(), 2);
            

    public int SumOfSquares() => Enumerable.Range(1,Value).Select(i=> i*i).Sum();

    public int DifferenceOfSquares() => SquareOfSums() - SumOfSquares();
}