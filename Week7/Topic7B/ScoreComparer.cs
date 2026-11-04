using System.Collections.Generic;

public class ScoreComparer : IComparer<ScoreEntry>
{
    public int Compare(ScoreEntry x, ScoreEntry y)
    {
        int result = x.Score.CompareTo(y.Score);

        if (result == 0)
        {
            result = x.StageReached.CompareTo(y.StageReached);
        }

        return result;
    }
}
