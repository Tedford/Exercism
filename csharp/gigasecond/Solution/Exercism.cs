using System;

public static class Gigasecond
{
    public static DateTime Date(DateTime dob) => dob.AddSeconds(Math.Pow(10,9));
}