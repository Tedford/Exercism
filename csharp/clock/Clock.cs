using System;

public class Clock : IEquatable<Clock>
{
    private const int MinutesPerDay = 24 * 60;
    private const int MinutesPerHour = 60;
    private readonly int _minutes;

    public Clock(int hours) => _minutes = hours * MinutesPerHour % (MinutesPerDay);

    public Clock(int hours, int minutes) => _minutes = (hours* MinutesPerHour + minutes) % MinutesPerDay;

    public Clock Add(int minutesToAdd) => ClockFromMinutes(_minutes + minutesToAdd);

    private Clock ClockFromMinutes(int totalMinutes)
    {
        int hours = totalMinutes / MinutesPerHour;
        int minutes = totalMinutes % MinutesPerHour;
        return new Clock(hours, minutes);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        int totalMinutes = (_minutes - minutesToSubtract) % MinutesPerDay;
        if (totalMinutes < 0)
        {
            totalMinutes = MinutesPerDay + totalMinutes;
        }

        return ClockFromMinutes(totalMinutes);
    }

    public override int GetHashCode() => _minutes.GetHashCode();

    public override string ToString() => $"{_minutes / MinutesPerHour:00}:{_minutes % MinutesPerHour:00}";

    public override bool Equals(object obj) => base.Equals(obj as Clock);

    public bool Equals(Clock other) => other == null ? false : other._minutes == _minutes;
}