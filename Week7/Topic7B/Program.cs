using System;
using System.Collections.Generic;

public enum Priority
{
    HighPriority,
    MediumPriority,
    LowPriority,
}

class Program
{
    static void Main()
    {
        // task 1, score -> name
        SortedDictionary<int, string> sortedScores = new SortedDictionary<int, string>();

        sortedScores.Add(120, "Alice");
        sortedScores.Add(95, "Bob");
        sortedScores.Add(210, "Charlie");
        sortedScores.Add(45, "David");
        sortedScores.Add(300, "Emma");
        sortedScores.Add(160, "Frank");
        sortedScores.Add(80, "Grace");
        sortedScores.Add(250, "Henry");
        sortedScores.Add(30, "Ivy");
        sortedScores.Add(180, "Jack");

        List<int> keys = new List<int>(sortedScores.Keys);

        keys.Reverse();

        Console.WriteLine("Top three:");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(keys[i] + " - " + sortedScores[keys[i]]);
        }

        Console.WriteLine("Bottom three:");

        for (int i = 0; i < 3; i++)
        {
            int key = keys[keys.Count - 1 - i];

            Console.WriteLine(key + " - " + sortedScores[key]);
        }

        sortedScores.Remove(95);

        Console.WriteLine("After Bob left:");

        foreach (KeyValuePair<int, string> entry in sortedScores)
        {
            Console.WriteLine(entry.Key + " - " + entry.Value);
        }

        try
        {
            sortedScores.Add(120, "Someone Else");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        sortedScores.Add(130, "Alice");

        Console.WriteLine("Same name with another score is ok");


        // task 2, ScoreEntry as the key
        List<ScoreEntry> entries = new List<ScoreEntry>
        {
            new ScoreEntry(120, 3),
            new ScoreEntry(95, 2),
            new ScoreEntry(210, 5),
            new ScoreEntry(45, 1),
            new ScoreEntry(300, 7),
            new ScoreEntry(160, 4),
            new ScoreEntry(80, 2),
            new ScoreEntry(250, 6),
            new ScoreEntry(30, 1),
            new ScoreEntry(180, 4),
        };

        List<Player> players = new List<Player>
        {
            new Player("Alice"),
            new Player("Bob"),
            new Player("Charlie"),
            new Player("David"),
            new Player("Emma"),
            new Player("Frank"),
            new Player("Grace"),
            new Player("Henry"),
            new Player("Ivy"),
            new Player("Jack"),
        };

        // no comparer yet, same error as the sorted set
        SortedDictionary<ScoreEntry, Player> noComparer = new SortedDictionary<ScoreEntry, Player>();

        try
        {
            noComparer.Add(entries[0], players[0]);
            noComparer.Add(entries[1], players[1]);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Without comparer: " + ex.Message);
        }

        SortedDictionary<ScoreEntry, Player> sortedScores2 = new SortedDictionary<ScoreEntry, Player>(new ScoreComparer());

        for (int i = 0; i < entries.Count; i++)
        {
            sortedScores2.Add(entries[i], players[i]);
        }

        List<ScoreEntry> keys2 = new List<ScoreEntry>(sortedScores2.Keys);

        keys2.Reverse();

        Console.WriteLine("Top three:");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(keys2[i].Score + " stage " + keys2[i].StageReached + " - " + sortedScores2[keys2[i]].Name);
        }

        Console.WriteLine("Bottom three:");

        for (int i = 0; i < 3; i++)
        {
            ScoreEntry key = keys2[keys2.Count - 1 - i];

            Console.WriteLine(key.Score + " stage " + key.StageReached + " - " + sortedScores2[key].Name);
        }

        sortedScores2.Remove(entries[1]);

        Console.WriteLine("After Bob left:");

        foreach (KeyValuePair<ScoreEntry, Player> entry in sortedScores2)
        {
            Console.WriteLine(entry.Key.Score + " - " + entry.Value.Name);
        }

        sortedScores2.Add(new ScoreEntry(120, 6), new Player("Latecomer"));

        Console.WriteLine("Same score but another stage is ok");

        sortedScores2.Add(new ScoreEntry(999, 8), players[0]);

        Console.WriteLine("Another score with the same player is ok");


        // task 3, priority queue with int
        PriorityQueue<Player, int> eventQueue = new PriorityQueue<Player, int>();

        eventQueue.Enqueue(new Player("Alice"), 3);
        eventQueue.Enqueue(new Player("Bob"), 1);
        eventQueue.Enqueue(new Player("Charlie"), 2);

        while (eventQueue.Count != 0)
        {
            Console.WriteLine(eventQueue.Dequeue());
        }

        eventQueue.Enqueue(new Player("David"), 2);
        eventQueue.Enqueue(new Player("Emma"), 2);

        Console.WriteLine("Two players with priority 2:");

        while (eventQueue.Count != 0)
        {
            Console.WriteLine(eventQueue.Dequeue());
        }


        // task 4, priority queue with the enum
        PriorityQueue<Player, Priority> eventQueue2 = new PriorityQueue<Player, Priority>();

        eventQueue2.Enqueue(new Player("Alice"), Priority.MediumPriority);
        eventQueue2.Enqueue(new Player("Bob"), Priority.HighPriority);
        eventQueue2.Enqueue(new Player("Charlie"), Priority.LowPriority);
        eventQueue2.Enqueue(new Player("David"), Priority.HighPriority);

        while (eventQueue2.Count != 0)
        {
            Console.WriteLine(eventQueue2.Dequeue());
        }
    }
}
