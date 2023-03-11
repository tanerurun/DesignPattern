internal class Program
{
    private static void Main(string[] args)
    {
        CreditManager creditManager = new CreditManager();
        creditManager.Calculate();

        Console.WriteLine(creditManager.Calculate());
    }
}

abstract class CreditBase
{
    public abstract int Calculate();
}

class CreditManager : CreditBase
{
    public override int Calculate()
    {
        int result = 1;
        for (int i = 0; i < 5; i++)
        {
            result += 1;
            Thread.Sleep(100);
        }
        return result;
    }
}