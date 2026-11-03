namespace PracB.Tests;

public class BankAccountTests
{
    [Fact]
    public void DepositDecimalTest()
    {
        BankAccount account = new BankAccount("MAX", 1000m);

        account.Deposit(100m);

        Assert.Equal(1100m, account.Balance);
    }

    [Fact]
    public void DepositIntTest()
    {
        BankAccount account = new BankAccount("John", 1000m);

        account.Deposit(100);

        Assert.Equal(1100m, account.Balance);
    }

    [Fact]
    public void DepositDoubleTest()
    {
        BankAccount account = new BankAccount("Sam", 1000m);

        account.Deposit(100.5);

        Assert.Equal(1100.5m, account.Balance);
    }

    [Fact]
    public void WithdrawTest()
    {
        BankAccount account = new BankAccount("Python", 1000m);

        account.Withdraw(200m);

        Assert.Equal(800m, account.Balance);
    }

    [Fact]
    public void WithdrawException()
    {
        BankAccount account = new BankAccount("Lucky", 1000m);

        Assert.Throws<Exception>(() => account.Withdraw(1500m));
    }
}