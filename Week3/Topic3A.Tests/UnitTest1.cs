public class BankAccountTests
{
    [Fact]
    public void DepositTest()
    {
        BankAccount account = new BankAccount("Max", 100m);

        account.Deposit(50m);

        Assert.Equal(150m, account.Balance);
    }

    [Fact]
    public void WithdrawTest()
    {
        BankAccount account = new BankAccount("Max", 100m);

        account.Withdraw(40m);

        Assert.Equal(60m, account.Balance);
    }

    [Fact]
    public void WithdrawTooMuchTest()
    {
        BankAccount account = new BankAccount("Max", 100m);

        Assert.Throws<ArgumentException>(() => account.Withdraw(200m));
    }

    [Fact]
    public void SavingsConstructorTest()
    {
        SavingsAccount account = new SavingsAccount("Jordan", 1500m, 3.5m);

        Assert.Equal("Jordan", account.Owner);
        Assert.Equal(1500m, account.Balance);
        Assert.Equal(3.5m, account.InterestRate);
    }

    [Fact]
    public void ApplyInterestTest()
    {
        SavingsAccount account = new SavingsAccount("Jordan", 1500m, 3.5m);

        account.ApplyInterest();

        Assert.Equal(1552.50m, account.Balance);
    }

    [Fact]
    public void CheckingWithdrawDeductsFeeTest()
    {
        CheckingAccount account = new CheckingAccount("Max", 500m, 2.5m);

        account.Withdraw(100m);

        Assert.Equal(397.50m, account.Balance);
    }

    [Fact]
    public void SavingsDisplayInfoTest()
    {
        SavingsAccount account = new SavingsAccount("Jordan", 1500m, 3.5m);
        TextWriter original = Console.Out;
        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        account.DisplayAccountInfo();

        Console.SetOut(original);
        Assert.Contains("Interest rate: 3.5%", sw.ToString());
    }

    [Fact]
    public void CheckingDisplayInfoTest()
    {
        CheckingAccount account = new CheckingAccount("Max", 500m, 2.5m);
        TextWriter original = Console.Out;
        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        account.DisplayAccountInfo();

        Console.SetOut(original);
        Assert.Contains("Transaction fee: $2.50", sw.ToString());
    }
}
