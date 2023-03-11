internal class Program
{
    private static void Main(string[] args)
    {

        ScoringAlgorithm scoringAlgorithm;
        Console.WriteLine("Mans");
        scoringAlgorithm = new MensScoringAlgoritm();

        Console.WriteLine(scoringAlgorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));
    }
}

abstract class ScoringAlgorithm
{
    public int GenerateScore(int hits, TimeSpan time)
    {
        int score = CaculateBaseScore(hits);
        int reduction = CaculateReduction(time);
        return CaculateOverallScore(score, reduction);
    }

    protected abstract int CaculateOverallScore(int score, int reduction);
    protected abstract int CaculateReduction(TimeSpan time);
    protected abstract int CaculateBaseScore(int hits);

}

class MensScoringAlgoritm : ScoringAlgorithm
{
    protected override int CaculateBaseScore(int hits)
    {
        return hits * 100;
    }

    protected override int CaculateOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    protected override int CaculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 5;
    }
}

class ChilderensScoringAlgoritm : ScoringAlgorithm
{
    protected override int CaculateBaseScore(int hits)
    {
        return hits * 100;
    }

    protected override int CaculateOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    protected override int CaculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 3;
    }
}
class WomensScoringAlgoritm : ScoringAlgorithm
{
    protected override int CaculateBaseScore(int hits)
    {
        return hits * 100;
    }

    protected override int CaculateOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    protected override int CaculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 4;
    }
}