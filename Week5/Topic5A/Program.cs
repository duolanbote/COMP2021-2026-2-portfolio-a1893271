string[] names = new string[]
{
    "Max",
    "John",
    "Alice",
    "Tom",
    "Michael",
    "Jack",
    "Emma",
    "David",
    "Alexander",
    "Sam"
};

Console.WriteLine("All names:");

foreach (string name in names)
{
    Console.WriteLine(name);
}


string longest = names[0];
string shortest = names[0];

foreach (string name in names)
{
    if (name.Length > longest.Length)
    {
        longest = name;
    }

    if (name.Length < shortest.Length)
    {
        shortest = name;
    }
}

Console.WriteLine("Longest name: " + longest);
Console.WriteLine("Shortest name: " + shortest);


foreach (string name in names)
{
    Console.WriteLine(name);
}

Array.Sort(names);

Console.WriteLine("sorting:");

foreach (string name in names)
{
    Console.WriteLine(name);
}



foreach (string name in names)
{
    Console.WriteLine(name);
}

Array.Reverse(names);

Console.WriteLine("Reversing:");

foreach (string name in names)
{
    Console.WriteLine(name);
}