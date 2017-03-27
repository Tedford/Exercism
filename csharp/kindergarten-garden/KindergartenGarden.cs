using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class Garden
{
    private readonly Dictionary<string, IEnumerable<Plant>> _plants;
    private static readonly Dictionary<char, Plant> Lookup = new Dictionary<char, Plant>
    {
        ['c'] = Plant.Clover,
        ['v'] = Plant.Violets,
        ['r'] = Plant.Radishes,
        ['g'] = Plant.Grass
    };

    public Garden(IEnumerable<string> children, string windowSills)
    {
        var rows = windowSills.ToLower().Split('\n');

        _plants = children.OrderBy(i => i)
                          .Select((c, i) => new { Child = c, Plants = rows.SelectMany(r => GetPlant(r, i * 2)).Where(e => e != default(char)).Select(p => Lookup[p]) })
                          .ToDictionary(t => t.Child, t => t.Plants);
    }

    private IEnumerable<char> GetPlant(string row, int index)
    {
        yield return row.ElementAtOrDefault(index);
        yield return row.ElementAtOrDefault(index + 1);
    }

    public IEnumerable<Plant> GetPlants(string child)
    {
        if (!_plants.TryGetValue(child, out IEnumerable<Plant> plants))
        {
            return Enumerable.Empty<Plant>();
        }
        else
        {
            return plants;
        }
    }

    public static Garden DefaultGarden(string windowSills) => new Garden(new[] { "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry" }, windowSills);
}