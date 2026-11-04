using System;
using System.Collections.Generic;
using System.Linq;
using ScottPlot;

class Program
{
    static void Main()
    {
        // Task 1
        SortedSet<int> scores = new SortedSet<int>();

        scores.Add(65);
        scores.Add(80);
        scores.Add(45);
        scores.Add(92);
        scores.Add(70);
        scores.Add(55);
        scores.Add(88);
        scores.Add(76);
        scores.Add(60);
        scores.Add(95);

        Console.WriteLine("Original scores:");
        DisplayScores(scores);

        scores.Add(100);

        Console.WriteLine("After adding a new high score:");
        DisplayScores(scores);

        scores.Add(80);

        Console.WriteLine("After adding a duplicate score:");
        DisplayScores(scores);

        // Task 2
        BankAccount account1 = new BankAccount("Alice", 1000);
        BankAccount account2 = new BankAccount("Bob", 2500);
        BankAccount account3 = new BankAccount("Charlie", 800);
        BankAccount account4 = new BankAccount("David", 3200);
        BankAccount account5 = new BankAccount("Emma", 1500);
        BankAccount account6 = new BankAccount("Frank", 900);
        BankAccount account7 = new BankAccount("Grace", 2100);
        BankAccount account8 = new BankAccount("Henry", 1700);
        BankAccount account9 = new BankAccount("Ivy", 4000);
        BankAccount account10 = new BankAccount("Jack", 1200);

        // no comparer yet, this is the runtime error
        SortedSet<BankAccount> noComparer = new SortedSet<BankAccount>();

        try
        {
            noComparer.Add(account1);
            noComparer.Add(account2);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Runtime error: " + ex.Message);
        }

        SortedSet<BankAccount> sortedAccounts = new SortedSet<BankAccount>(new BankComparer());

        sortedAccounts.Add(account1);
        sortedAccounts.Add(account2);
        sortedAccounts.Add(account3);
        sortedAccounts.Add(account4);
        sortedAccounts.Add(account5);
        sortedAccounts.Add(account6);
        sortedAccounts.Add(account7);
        sortedAccounts.Add(account8);
        sortedAccounts.Add(account9);
        sortedAccounts.Add(account10);

        Console.WriteLine("Sorted accounts:");
        DisplayAccounts(sortedAccounts);

        sortedAccounts.Add(new BankAccount("Kate", 5000));

        Console.WriteLine("After adding a new highest balance:");
        DisplayAccounts(sortedAccounts);

        sortedAccounts.Add(new BankAccount("Alice", 1000));

        Console.WriteLine("After adding a duplicate account:");
        DisplayAccounts(sortedAccounts);

        // Task 3
        double[] balances = sortedAccounts.Select(account => (double)account.Balance).ToArray();

        ScottPlot.Plot plot = new();

        plot.Add.Bars(balances);
        plot.XLabel("Ranking");
        plot.YLabel("Account Balance");
        plot.Axes.Bottom.TickLabelStyle.FontSize = 20;
        plot.Axes.Margins(bottom: 0, top: .2);
        plot.SavePng("Topic7A-Task3.png", 800, 600);

        Console.WriteLine("Saved Topic7A-Task3.png");
    }

    static void DisplayScores(SortedSet<int> scores)
    {
        int lowest = int.MaxValue;
        int highest = int.MinValue;

        foreach (int score in scores)
        {
            Console.WriteLine(score);

            if (score < lowest)
            {
                lowest = score;
            }

            if (score > highest)
            {
                highest = score;
            }
        }

        Console.WriteLine("Lowest score: " + lowest);
        Console.WriteLine("Highest score: " + highest);
    }

    static void DisplayAccounts(SortedSet<BankAccount> accounts)
    {
        foreach (BankAccount account in accounts)
        {
            Console.WriteLine(account);
        }
    }
}
