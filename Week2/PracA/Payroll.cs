using System;

public class Payroll
{
    public decimal Hours
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("hours can't be negative");
            }

            field = value;
        }
    }

    public decimal Rate
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("rate can't be negative");
            }

            field = value;
        }
    }

    public decimal TaxRate
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("tax rate can't be negative");
            }

            field = value;
        }
    }

    public Payroll(double hours, decimal rate, decimal taxRate)
    {
        Hours = (decimal)hours;
        Rate = rate;
        TaxRate = taxRate;
    }

    public decimal CalculateNetPay()
    {
        decimal gross = Hours * Rate;
        decimal tax = gross * TaxRate;
        return gross - tax;
    }

    public void ChangeTaxRate(decimal newRate)
    {
        TaxRate = newRate;
    }
}
