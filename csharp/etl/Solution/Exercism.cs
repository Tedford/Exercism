using System.Collections.Generic;

public static class ETL
{
    public static Dictionary<string,int> Transform(Dictionary<int,IList<string>> input)
    {
        var output = new Dictionary<string, int>();
        foreach(var entry in input)
        {
            foreach(var letter in entry.Value)
            {
                output[letter.ToLower()] = entry.Key;
            }
        }

        return output;
    }
}