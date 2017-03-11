using System;
using System.Linq;

public class Robot
{
    private static readonly char[] Numbers = Enumerable.Range(0, 10).Select(i => (char)('0' + i)).ToArray();
    private static readonly char[] Letters = Enumerable.Range(0, 26).Select(i => (char)('A' + i)).ToArray();
    private static readonly Random Random = new Random();

    public Robot()
    {
        Reset();
    }

    public string Name { get; private set; }

    public void Reset()
    {
        Func<char[], char> selector = candidates => candidates[Random.Next() % candidates.Length];
        Name = $"{selector(Letters)}{selector(Letters)}{selector(Numbers)}{selector(Numbers)}{selector(Numbers)}";
    }
}