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


List<string> students = new List<string>();


//task2

students.Add("Max");
students.Add("Aya");
students.Add("Trace");
students.Add("Tom");


students.Insert(1, "Emma");

students.Remove("Tom");

students.AddRange(new string[]
{"David","Jack","Michael", "Sam", "Alex666", "Prince"});

Console.WriteLine("Student List:");

foreach (string student in students)
{
    Console.WriteLine(student);
}

//search
string searchName = "Alice";

for (int i = 0; i < students.Count; i++)
{
    if (students[i] == searchName)
    {
        Console.WriteLine(searchName + " is at index " + i);
    }
}

//contain
string partialName = "a";

Console.WriteLine("Names containing " + partialName + ":");

foreach (string student in students)
{
    if (student.Contains(partialName))
    {
        Console.WriteLine(student);
    }
}

//list length
int Length = 0;

foreach (string student in students)
{
    Length += student.Length;
}

Console.WriteLine("\nTotal length: " + Length);


// Convert
List<string> oldNames = new List<string>(names);


// Add Task 1 names to Task 2 List
students.AddRange(oldNames);


foreach (string student in students)
{
    Console.WriteLine(student);
}



//uncompleted: task2 output and task3 reflection

//must be finished when i back home

//cao ni ma yi ding yao ji de
