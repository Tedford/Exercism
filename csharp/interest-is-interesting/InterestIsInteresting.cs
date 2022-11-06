using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        var rate = 3.213f;
        if (balance >= 5000)
        {
            rate = 2.475f;
        }
        else if (balance >= 1000)
        {
            rate = 1.621f;
        }
        else if (balance >= 0)
        {
            rate = .5f;
        }
        return rate;
    }

    public static decimal Interest(decimal balance) => (decimal)InterestRate(balance) * balance / 100;

    public static decimal AnnualBalanceUpdate(decimal balance) => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var years = 0;
        do {
            balance = AnnualBalanceUpdate(balance);
            years++;
        } while ( balance < targetBalance);
        return years;
    }
}
