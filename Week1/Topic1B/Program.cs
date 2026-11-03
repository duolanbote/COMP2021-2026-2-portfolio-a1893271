using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        TodoApp app = new TodoApp();

        while (true)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (line == null)
            {
                return;
            }

            line = line.Trim();
            if (line.Length == 0)
            {
                continue;
            }

            string command = line.Split(' ')[0].ToLower();
            string rest = line.Substring(command.Length).Trim();

            try
            {
                switch (command)
                {
                    case "add":
                        app.Add(rest);
                        break;
                    case "show":
                        app.Show();
                        break;
                    case "remove":
                        app.Remove(ParseNumber(rest));
                        break;
                    case "clear":
                        app.Clear();
                        break;
                    case "tag":
                        AddTag(app, rest);
                        break;
                    case "get-tagged":
                        ListTagged(app, rest);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("unknown command");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
            }
        }
    }

    static void AddTag(TodoApp app, string rest)
    {
        string[] parts = rest.Split(' ', 2);
        if (parts.Length < 2)
        {
            throw new ArgumentException("use: tag <number> <name>");
        }

        app.Tag(ParseNumber(parts[0]), parts[1]);
    }

    static void ListTagged(TodoApp app, string name)
    {
        foreach (string item in app.GetTagged(name))
        {
            Console.WriteLine(item);
        }
    }

    static int ParseNumber(string text)
    {
        if (int.TryParse(text, out int number))
        {
            return number;
        }

        throw new ArgumentException($"'{text}' is not a number");
    }
}
