using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
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
}