public class BankAccount
{
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new ArgumentException("not enough money in the account");
        }

        Balance -= amount;
    }

    public virtual void DisplayAccountInfo()
    {
        Console.WriteLine($"Account: {GetType().Name}");
        Console.WriteLine($"Owner: {Owner}");
        Console.WriteLine($"Balance: ${Balance:F2}");
    }
}
