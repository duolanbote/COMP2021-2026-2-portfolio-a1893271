using System;
using System.Collections.Generic;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> names = new List<string>()
        {
            "Tom",
            "Jack",
            "Alice",
            "David",
            "Bob",
            "Lucy",
            "John",
            "Emma",
            "Peter",
            "Mary"
        };

        var orderedNames = names.OrderBy(x => x);

        List<string> sortedNames = orderedNames.ToList();

        foreach (string name in sortedNames)
        {
            Console.WriteLine(name);
        }
    }
}