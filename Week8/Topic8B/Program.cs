using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Directory.CreateDirectory("Attachments");

        string path = "Attachments/MyTest.txt";

        // write the text file (no File.Exists check, so it always gets written)
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("Hello World");
        }

        // read it back with StreamReader
        using (StreamReader sr = File.OpenText(path))
        {
            string s;

            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }

        // same thing with File.ReadAllText
        Console.WriteLine(File.ReadAllText(path));

        List<Player> players = new List<Player>
        {
            new Player("Alice", 100, 20, 10),
            new Player("Bob", 80, 15, 5),
            new Player("Charlie", 120, 25, 15),
            new Player("David"),
            new Player("Emma")
        };

        foreach (Player player in players)
        {
            Console.WriteLine(player);
        }

        string playersPath = "Attachments/players.json";

        FileWriter(playersPath, players);

        List<Player> loadedPlayers = FileReader<List<Player>>(playersPath);

        Console.WriteLine("Loaded players:");

        foreach (Player player in loadedPlayers)
        {
            Console.WriteLine(player);
        }

        LinkedList<Player> playerList = new LinkedList<Player>();

        foreach (Player player in players)
        {
            playerList.AddLast(player);
        }

        string linkedPath = "Attachments/playersLinkedList.json";

        FileWriter(linkedPath, playerList);

        LinkedList<Player> loadedList = FileReader<LinkedList<Player>>(linkedPath);

        ShowMemory("LinkedList with " + loadedList.Count + " players");

        BenchmarkList();
        BenchmarkLinkedList();
    }

    public static void FileWriter<T>(string path, T objectToWrite) where T : class
    {
        string json = JsonSerializer.Serialize(objectToWrite);

        File.WriteAllText(path, json);
    }

    public static T FileReader<T>(string path) where T : class
    {
        string json = File.ReadAllText(path);

        return JsonSerializer.Deserialize<T>(json)!;
    }

    static void ShowMemory(string label)
    {
        GC.Collect();

        long heap = GC.GetGCMemoryInfo().HeapSizeBytes;
        long peak = Process.GetCurrentProcess().PeakWorkingSet64;

        Console.WriteLine(label);
        Console.WriteLine("HeapSizeBytes: " + heap);
        Console.WriteLine("PeakWorkingSet64: " + peak);
    }

    static void BenchmarkList()
    {
        List<Player> list = new List<Player>();

        for (int i = 0; i < 10_000; i++)
        {
            list.Add(new Player("Player" + i));
        }

        FileWriter("Attachments/list10000.json", list);

        List<Player> loaded = FileReader<List<Player>>("Attachments/list10000.json");

        ShowMemory("List with " + loaded.Count + " players");
    }

    static void BenchmarkLinkedList()
    {
        LinkedList<Player> list = new LinkedList<Player>();

        for (int i = 0; i < 10_000; i++)
        {
            list.AddLast(new Player("Player" + i));
        }

        FileWriter("Attachments/linkedList10000.json", list);

        LinkedList<Player> loaded = FileReader<LinkedList<Player>>("Attachments/linkedList10000.json");

        ShowMemory("LinkedList with " + loaded.Count + " players");
    }
}
