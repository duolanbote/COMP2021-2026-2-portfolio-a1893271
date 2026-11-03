using System;

class Program
{
    const double TaxRate = 0.2;

    static void Main()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine() ?? "";

        try
        {
            Console.Write("Hours worked: ");
            double hours = double.Parse(Console.ReadLine() ?? "");

            Console.Write("Hourly rate: ");
            double rate = double.Parse(Console.ReadLine() ?? "");

            Console.WriteLine($"{name} earned ${CalculatePay(hours, rate):F2} after tax.");
        }
        catch (FormatException)
        {
            Console.WriteLine("hours and rate have to be numbers");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Person p = new Person("Casey", "Nguyen", 21);
        Console.WriteLine(p.FullName());
        Console.WriteLine(p.IsAdult());
    }

    static double CalculatePay(double hours, double rate)
    {
        if (hours < 0 || rate < 0)
        {
            throw new ArgumentException("Hours and rate must be positive.");
        }

        double gross = hours * rate;
        double tax = gross * TaxRate;
        return gross - tax;
    }
}
