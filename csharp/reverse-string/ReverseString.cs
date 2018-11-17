using System;
using System.Collections.Generic;

public static class ReverseString
{
    public static string Reverse(string input) => string.IsNullOrEmpty(input) ? input: String.Join(String.Empty,ReverseKernel(input));
    private static IEnumerable<char> ReverseKernel(string input){
        for(int i= input.Length-1; i > -1; i--){
            yield return input[i];
        }
    }
}