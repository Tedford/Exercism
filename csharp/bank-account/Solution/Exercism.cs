using System;
using System.Threading;

public class BankAccount
{

    private bool _opened;
    private int _balance;

    public int Balance
    {
        get
        {
            AssertOpen();
            return _balance;
        }
    }

    private void AssertOpen()
    {
        if (!_opened)
        {
            throw new InvalidOperationException("The account is closed.  No activity is allowed.");
        }
    }

    public void Open() => _opened = true;

    public void Close() => _opened = false;


    public void UpdateBalance(int amount)
    {
        AssertOpen();
        Interlocked.Add(ref _balance, amount);
    }

}