using System;
using System.Linq;

public enum TriangleKind
{
    Equilateral,
    Isosceles,
    Scalene
}

public static class Triangle
{
    public static TriangleKind Kind(decimal side1, decimal side2, decimal side3)
    {
        var sides = new[] { side1, side2, side3 }.OrderBy(i => i).ToArray();

        if( sides.Any(i=> i <= 0))
        {
            throw new TriangleException("A sides must be greater than 0 in length");
        }

        if (sides[0] + sides[1] <= sides[2])
        {
            throw new TriangleException("The triangle rule is violated");
        }

        TriangleKind kind;
        if (sides[0] == sides[1] && sides[1] == sides[2])
        {
            kind = TriangleKind.Equilateral;
        }
        else if (sides[0] == sides[1] || sides[1] == sides[2])
        {
            kind = TriangleKind.Isosceles;
        }
        else
        {
            kind = TriangleKind.Scalene;
        }

        return kind;
    }
}

public class TriangleException : Exception {
    public TriangleException()
    {
    }

    public TriangleException(string message) : base(message)
    {
        
    }
}