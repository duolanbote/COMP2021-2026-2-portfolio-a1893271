class Program
{
    static void Main()
    {
        SavingsAccount savings = new SavingsAccount("Jordan", 1500m, 3.5m);

        savings.DisplayAccountInfo();
        savings.ApplyInterest();
        Console.WriteLine($"Balance after interest: ${savings.Balance:F2}");

        Console.WriteLine();

        CheckingAccount checking = new CheckingAccount("Max", 500m, 2.5m);

        checking.DisplayAccountInfo();
        checking.Withdraw(100m);
        Console.WriteLine($"Balance after withdraw: ${checking.Balance:F2}");
    }
}
