namespace Topic4a;
public static class BrokenProgram
{
  static void Main(string[] args)
  {
    const string input = """
       23
       + 
       77
       + 
        3
       + 
      457
       * 
        2
         
      """;
    int total = 0;
    List<int> items = [];
    List<string> symbols = [];

    string[] lines = input.Split("\n");

    for (int i = 0; i < 9; i += 2) //10 line
    {
        items.Add(int.Parse(lines[i].Trim()));

        if (i != 0)
        {
            symbols.Add(lines[i - 1].Trim());
        }
    }

    foreach (var (i, value) in items.Index())
    {
      if (i == 0) { total = value; }
      else if (symbols[i - 1] == "*")
      {
        total *= value;
      }
      else
      {
        total += value;
      }
    }
    Console.WriteLine("Total was: " + total);
    Console.WriteLine("Expected total was: 1120");
    Console.WriteLine(total == 1120 ? "Your answer was RIGHT!" : "Your answer was WRONG!\nGo and fix it.");
  }
}