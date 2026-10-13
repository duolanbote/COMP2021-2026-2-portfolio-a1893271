using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ScottPlot;


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

        // task2
        
    


        int iterations = 20;

        List<double> appendElapsedList = new List<double>();
        List<double> builderElapsedList = new List<double>();

        Stopwatch watch = new Stopwatch();

        // Method 1: String
        for (int pass = 1; pass <= iterations; pass++)
        {
            string aOutput = "";

            watch.Restart();

            for (int i = 0; i < pass * 10000; i++)
            {
                aOutput += "z";
            }

            watch.Stop();

            appendElapsedList.Add(watch.Elapsed.TotalMilliseconds);
        }

        // Method 2: StringBuilder
        for (int pass = 1; pass <= iterations; pass++)
        {
            StringBuilder bOutput = new StringBuilder();

            watch.Restart();

            for (int i = 0; i < pass * 10000; i++)
            {
                bOutput.Append("z");
            }

            watch.Stop();

            builderElapsedList.Add(watch.Elapsed.TotalMilliseconds);
        }

        // Create Append graph
        ScottPlot.Plot appendPlot = new();
        appendPlot.Add.Bars(appendElapsedList.ToArray());
        appendPlot.Title("String Append");
        appendPlot.XLabel("Pass");
        appendPlot.YLabel("Time (ms)");
        appendPlot.SavePng("appendPlot.png", 800, 600);

        // Create StringBuilder graph
        ScottPlot.Plot buildPlot = new();
        buildPlot.Add.Bars(builderElapsedList.ToArray());
        buildPlot.Title("StringBuilder");
        buildPlot.XLabel("Pass");
        buildPlot.YLabel("Time (ms)");
        buildPlot.SavePng("buildPlot.png", 800, 600);

        Console.WriteLine("Graphs saved!");

    }
}
