
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<string> history = new Stack<string>();

        history.Push("Text");
        history.Push("Image");
        history.Push("Colour");

        Console.WriteLine("Initial Stack:");

        foreach (string action in history)
        {
            Console.WriteLine(action);
        }

        Console.WriteLine("\nTop item:");
        Console.WriteLine(history.Peek());

        history.Pop();

        Console.WriteLine("Other item Pop:");

        foreach (string action in history)
        {
            Console.WriteLine(action);
        }
    }
}