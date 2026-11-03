using System;
using System.Collections.Generic;

public class TodoApp
{
    private readonly List<string> tasks = new List<string>();

    // tag -> task numbers
    private readonly Dictionary<string, List<int>> tags = new Dictionary<string, List<int>>();

    public void Add(string item)
    {
        if (string.IsNullOrWhiteSpace(item))
        {
            throw new ArgumentException("nothing to add");
        }

        tasks.Add(item.Trim());
    }

    public void Show()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("list is empty");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    public void Remove(int number)
    {
        CheckRange(number);
        tasks.RemoveAt(number - 1);
    }

    public void Clear()
    {
        tasks.Clear();
        tags.Clear();
    }

    public void Tag(int number, string name)
    {
        CheckRange(number);

        name = name.Trim();
        if (name.Length == 0)
        {
            throw new ArgumentException("tag name is empty");
        }

        if (!tags.ContainsKey(name))
        {
            tags[name] = new List<int>();
        }

        if (tags[name].Contains(number))
        {
            throw new ArgumentException($"task {number} already has the tag {name}");
        }

        tags[name].Add(number);
    }

    public List<string> GetTagged(string name)
    {
        name = name.Trim();

        if (!tags.ContainsKey(name))
        {
            throw new KeyNotFoundException($"there is no tag called {name}");
        }

        List<string> found = new List<string>();
        foreach (int number in tags[name])
        {
            found.Add(tasks[number - 1]);
        }

        return found;
    }

    private void CheckRange(int number)
    {
        if (number < 1 || number > tasks.Count)
        {
            throw new ArgumentException($"there is no task {number}");
        }
    }
}
