using System;

class Program
{
    static void Main()
    {
        Payroll payroll = new Payroll(38, 42.5m, 0.2m);
        Console.WriteLine($"net pay: {payroll.CalculateNetPay():F2}");

        payroll.ChangeTaxRate(0.3m);
        Console.WriteLine($"net pay after tax change: {payroll.CalculateNetPay():F2}");
    }
}
