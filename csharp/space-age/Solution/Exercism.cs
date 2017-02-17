using System;

public class SpaceAge
{
    private const double SecondsInEarthYear = 31557600;

    public Int64 Seconds { get; }

    public SpaceAge(Int64 seconds)
    {
        Seconds = seconds;
    }

    private double CalculateAge(double multipler) => Seconds / (multipler * SecondsInEarthYear);


    public double OnEarth() => CalculateAge(1);
    public double OnMercury() => CalculateAge(.2408467);
    public double OnVenus() => CalculateAge(.61519726);
    public double OnMars() => CalculateAge(1.8808158);
    public double OnJupiter() => CalculateAge(11.862615);
    public double OnSaturn() => CalculateAge(29.44798);
    public double OnUranus() => CalculateAge(84.016846);
    public double OnNeptune() => CalculateAge(164.79132);
}