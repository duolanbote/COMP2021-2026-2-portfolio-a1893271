
using System;
using System.IO;
using System.Colletcions.Generic;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string path = "MyTest.txt";

        
        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Hello World");
            }
        }

        // Read the file
        using (StreamReader sr = File.OpenText(path))
        {
            string s;

            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }

        
        Player p1 = new Player("Alice", 100, 20, 10);
        Player p2 = new Player("Bob", 80, 15, 5);
        Player p3 = new Player("Charlie", 120, 25, 15);
        Player p4 = new Player("David");
        Player p5 = new Player("Emma");

        
        List<Player> players = new List<Player>();

        
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        players.Add(p4);
        players.Add(p5);

        
        foreach (Player player in players)
        {
            Console.WriteLine(player);
        }

        // Serialize the list
        string json = JsonSerializer.Serialize(players);

        // Write JSON to a file
        File.WriteAllText("players.json", json);

        Console.WriteLine("Players saved!");

        // Read JSON from the file
        string loadedJson = File.ReadAllText("players.json");

        // Deserialize JSON into a list
        List<Player>? loadedPlayers =
            JsonSerializer.Deserialize<List<Player>>(loadedJson);

        // Print loaded players
        Console.WriteLine("Loaded players:");

        if (loadedPlayers != null)
        {
            foreach (Player player in loadedPlayers)
            {
                Console.WriteLine(player);
            }
        }

    }
}
