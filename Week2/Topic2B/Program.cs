BankAccount account = new BankAccount("John", 1000m);

Console.WriteLine("Owner: " + account.Owner);
Console.WriteLine("Balance: $" + account.Balance);

account.Deposit(500m);
Console.WriteLine("deposit: $" + account.Balance);

account.Withdraw(200m);
Console.WriteLine("withdrawal: $" + account.Balance);



BankAccount account2 = new BankAccount("John", 1000m);

account.Deposit(500m);
Console.WriteLine("decimal deposit: $" + account.Balance);

account.Deposit(200);
Console.WriteLine("int deposit: $" + account.Balance);

account.Deposit(50.5);
Console.WriteLine("double deposit: $" + account.Balance);