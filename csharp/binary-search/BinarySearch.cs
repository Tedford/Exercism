using System;
using System.Linq;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
	input = input ?? new int[0];
	var index = 0;

	while(input.Any())
	{
		int current = input.Length / 2;
		if (input[current] < value)
		{
			int size = input.Length - Math.Max(current,1);
			var array2 = new int[size];
			Array.Copy(input, current, array2, 0, size);
			input = array2;
			index += current;
		}
		else if (input[current] > value)
		{
			var array2 = new int[current];
			Array.Copy(input, array2, current);
			input = array2;
		}
		else 
		{
			return index + current;
		}
	}

	return -1;
    }
}