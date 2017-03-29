using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        Classification classification;
        switch (GetAliqutoSum(number))
        {
            case int aliquot when aliquot == number:
                classification = Classification.Perfect;
                break;
            case int aliquot when aliquot > number:
                classification = Classification.Abundant;
                break;
            case int aliquto when aliquto < number:
                classification = Classification.Deficient;
                break;
            default:
                throw new Exception("The factor is invalid");
        }

        return classification;
    }

    private static int GetAliqutoSum(int number) => Enumerable.Range(1, number - 1).Where(i => number % i == 0).Sum();
}
