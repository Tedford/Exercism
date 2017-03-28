using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> Proteins = new Dictionary<string, string>
    {
        ["AUG"] = "Methionine",
        ["UUU"] = "Phenylalanine",
        ["UUC"] = "Phenylalanine",
        ["UUA"] = "Leucine",
        ["UUG"] = "Leucine",
        ["UUG"] = "Leucine",
        ["UCU"] = "Serine",
        ["UCC"] = "Serine",
        ["UCA"] = "Serine",
        ["UCG"] = "Serine",
        ["UAU"] = "Tyrosine",
        ["UAC"] = "Tyrosine",
        ["UGU"] = "Cysteine",
        ["UGC"] = "Cysteine",
        ["UGG"] = "Tryptophan",
        ["UAA"] = "STOP",
        ["UAG"] = "STOP",
        ["UGA"] = "STOP",

    };

    public static string[] Translate(string sequence)
    {
        IEnumerable<char> Project(string source, int word)
        {
            int index = word * 3;
            yield return source.ElementAt(index);
            yield return source.ElementAt(index + 1);
            yield return source.ElementAt(index + 2);
        }

        return Enumerable.Range(0, sequence.Length / 3)
                .Select(i => new String(Project(sequence, i).ToArray()))
                .Select(i => Proteins.TryGetValue(i, out string protein) ? protein : throw new Exception($"Unknown codon {i} detected"))
                .TakeWhile(i => i != "STOP")
                .ToArray();


    }
}