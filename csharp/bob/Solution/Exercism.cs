using System.Text.RegularExpressions;

public static class Bob
{
    
    private static Regex shouting = new Regex("^[\\d,\\s]+[A-Z]+!$|^(?:[A-Z]+[^a-z]+)[!.?]?$", RegexOptions.Compiled);

    public static string Hey(string message)
    {
        message = message.Trim();
        string response = string.Empty;
        if( string.IsNullOrWhiteSpace(message))
        {
            response = "Fine. Be that way!";
        }
        else if (shouting.IsMatch(message))
        {
            response = "Whoa, chill out!";
        }
        else if(message.EndsWith("?"))
        {
            response = "Sure.";
        }
        else
        {
            response = "Whatever.";
        }
        return response;
    }
}
