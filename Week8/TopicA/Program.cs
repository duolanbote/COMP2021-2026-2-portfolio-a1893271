
using System;
using System.Collections;


class Program
{
    static void Main()
    {
        
        Hashtable scoreHash = new Hashtable();

        
        Player p1 = new Player("Alice");
        Player p2 = new Player("Bob");
        Player p3 = new Player("Charlie");
        Player p4 = new Player("David");
        Player p5 = new Player("Emma");

        scoreHash.Add(p1, 90);
        scoreHash.Add(p2, 75);
        scoreHash.Add(p3, 95);
        scoreHash.Add(p4, 60);
        scoreHash.Add(p5, 85);

        
        scoreHash.Add("Test", 100);


        
        List<DictionaryEntry> scores = new List<DictionaryEntry>();

        // Copy players into a List
        foreach (DictionaryEntry entry in scoreHash)
        {
            if (entry.Key is Player)
            {
                scores.Add(entry);
            }
        }

        // Find the highest score each time
        while (scores.Count > 0)
        {
            DictionaryEntry highest = scores[0];

            foreach (DictionaryEntry entry in scores)
            {
                if ((int)entry.Value > (int)highest.Value)
                {
                    highest = entry;
                }
            }

            Player player = (Player)highest.Key;

            Console.WriteLine(player.Name + ": " + highest.Value);

            scores.Remove(highest);
        }

    }
}
