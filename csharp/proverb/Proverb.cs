using System;
using System.Linq;

public static class Proverb
{
    private readonly static string Need = "For want of a {0} the {1} was lost.";
    private readonly static string[] Objects = new[] { "nail", "shoe", "horse", "rider", "message", "battle","kingdom"};

    public static string Line(int line) => line == 7 ? "And all for the want of a horseshoe nail." : string.Format(Need, Objects[line - 1], Objects[line]);

    public static string AllLines() => String.Join("\n", Enumerable.Range(1, 7).Select(i => Line(i)));
}