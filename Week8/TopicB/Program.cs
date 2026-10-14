
using System;
using System.IO;

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
    }
}
