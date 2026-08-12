BankAccount account = new BankAccount("John", 1000m);

Console.WriteLine("Owner: " + account.Owner);
Console.WriteLine("Balance: $" + account.Balance);

account.Deposit(500m);
Console.WriteLine("After deposit: $" + account.Balance);

account.Withdraw(200m);
Console.WriteLine("After withdrawal: $" + account.Balance);