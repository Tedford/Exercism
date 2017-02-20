using System;
using System.Collections.Generic;
using System.Linq;

public class DNA
{

    public Dictionary<char, int> NucleotideCounts { get; } = new Dictionary<char, int> { ['A'] = 0, ['C'] = 0, ['G'] = 0, ['T'] = 0 };

    public DNA(string sequence)
    {
        foreach( var g in sequence.GroupBy(i => i))
        {
            NucleotideCounts[g.Key] = g.Count();
        }
    }

    public int Count(char protein)
    {
        int count;

        if (!NucleotideCounts.TryGetValue(protein, out count))
        {
            throw new InvalidNucleotideException();
        }

        return count;
    }
}



public class InvalidNucleotideException : Exception
{
    public InvalidNucleotideException()
    {
    }
}