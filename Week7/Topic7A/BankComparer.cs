using System;
using System.Collections.Generic;

public class BankComparer : IComparer<BankAccount>
{
    public int Compare(BankAccount x, BankAccount y)
    {
        if (x.Balance < y.Balance)
        {
            return -1;
        }

        if (x.Balance > y.Balance)
        {
            return 1;
        }

        return string.Compare(x.Owner, y.Owner);
    }
}