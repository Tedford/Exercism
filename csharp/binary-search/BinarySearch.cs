using System;
using System.Linq;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        if (input == null || input.Length == 0)
        {
            return -1;
        }

        var start = 0;
        var end = Math.Max(input.Length - 1, 0);
        int current = 0;

        while (start <= end)
        {
            current = (start + end) / 2;

            // handle convergence
            if (end - start == 1)
            {
                if (input[end] == value)
                {
                    current = end;
                    end = -1;
                }
                else if (input[start] == value)
                {
                    current = start;
                    end = -1;
                }
                else
                {
                    current = -1;
                    end = -1;
                }
            }
            else if (input[current] < value)
            {
                start = current;
            }
            else if (input[current] > value)
            {
                end = current;
            }
            else
            {
                end = -1;
            }
        }

        return current;
    }
}