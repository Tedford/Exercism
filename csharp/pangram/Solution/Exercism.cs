using System.Linq;

public static class Pangram
{
    private static bool IsAsciiLetter(char c) => 'a' <= c && c <= 'z';
    public static bool IsPangram(string phrase) => phrase.ToLower().Where(i => IsAsciiLetter(i)).GroupBy(i=>i).ToDictionary(i => i.Key).Count == 26;
            
}