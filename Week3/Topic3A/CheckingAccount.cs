public class CheckingAccount : BankAccount
{
    public decimal TransactionFee { get; set; }

    public CheckingAccount(string owner, decimal balance, decimal transactionFee) : base(owner, balance)
    {
        TransactionFee = transactionFee;
    }

    // fee comes off on top of the withdraw
    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount);
        Balance -= TransactionFee;
    }

    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Transaction fee: ${TransactionFee:F2}");
    }
}
