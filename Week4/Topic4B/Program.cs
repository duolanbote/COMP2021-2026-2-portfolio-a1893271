namespace AdventDay7;

using System.Text;

/// <summary>
/// Class <c>Program</c> contains the magical tachyon manifold.
/// </summary>
public static class Program
{
    //This is a singleline comment.
    public static string FileToRead { get; set; } = Path.Combine(AppContext.BaseDirectory, "Example.txt");

    /// <summary>
    /// Puts a '|' under the 'S' so the beam starts going down.
    /// </summary>
    /// <param name="posX">column of the S</param>
    /// <param name="posY">row of the S</param>
    /// <param name="tachyonGrid">the grid we are editing</param>
    public static void processStart(int posX, int posY, List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY + 1];
        StringBuilder sb = new StringBuilder(line);
        sb[posX] = '|';
        line = sb.ToString();
        tachyonGrid[posY + 1] = line;
    }

    /*
    This is a multiline comment
    TODO: ProcessSplitter should return an int to add to the total, but it currently returns nothing.
    */

    /// <summary>
    /// Splits a beam that runs into a '^'. Only does anything when there is a '|' directly above,
    /// then the beam goes left and right on the same row.
    /// </summary>
    /// <param name="posX">column of the '^'</param>
    /// <param name="posY">row of the '^'</param>
    /// <param name="tachyonGrid">the grid we are editing</param>
    public static void processSplitter(int posX, int posY, List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY];
        StringBuilder sb = new StringBuilder(line);
        if (tachyonGrid[posY - 1][posX] == '|')
        {
            sb[posX - 1] = '|';
            sb[posX + 1] = '|';
            line = sb.ToString();
            tachyonGrid[posY] = line;
        }
    }

    /// <summary>
    /// Carries a beam straight down through an empty square, but only when the square above has a '|'.
    /// </summary>
    /// <param name="posX">column of the empty square</param>
    /// <param name="posY">row of the empty square</param>
    /// <param name="tachyonGrid">the grid we are editing</param>
    public static void processEmpty(int posX, int posY, List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY];
        StringBuilder sb = new StringBuilder(line);
        if (tachyonGrid[posY - 1][posX] == '|')
        {
            sb[posX] = '|';
            line = sb.ToString();
            tachyonGrid[posY] = line;
        }
    }

    public static void Main(string[] args)
    {
        var sr = new StreamReader(FileToRead);
        string srText = sr.ReadToEnd();
        int totalCount = 0;

        List<string> symbols = [.. srText.Split("\n")];
        List<string> tachyonGrid = symbols[..^1];

        Console.WriteLine("Begin Tachyon Manifold start state");
        foreach (var item in tachyonGrid)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("End Tachyon Manifold start state");

        for (int posY = 0; posY < tachyonGrid.Count; posY++)
        {
            var item = tachyonGrid[posY];
            foreach (var (posX, character) in item.Index())
            {
                if (character == 'S')
                {
                    processStart(posX, posY, tachyonGrid);
                }
                else if (character == '^')
                {
                    processSplitter(posX, posY, tachyonGrid);
                }
                else if (posY != 0)
                {
                    processEmpty(posX, posY, tachyonGrid);
                }
            }
        }
        Console.WriteLine($"Begin Taychon Manifold end state");

        foreach (var item in tachyonGrid)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"End Taychon Manifold end state");
        Console.WriteLine($"Total Tachyon Manifold splits were: {totalCount}");
        Console.WriteLine($"If using Example.txt, your total should be 21");
        Console.WriteLine($"If using Example.txt, your total is {(totalCount == 21 ? "RIGHT": "WRONG")}");
    }
}
