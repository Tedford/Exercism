using System;

public static class Year
{
    public static bool IsLeap(int year)
    {
        Func<int, int, bool> isDivisble = (value, multiple) => value % multiple == 0;
        bool by4 = isDivisble(year, 4);
        bool by100 = isDivisble(year, 100);
        bool by400 = isDivisble(year, 400);

        return by4 && (!by100 || by100 && by400);
    }
}