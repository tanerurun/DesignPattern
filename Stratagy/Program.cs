internal class Program
{
    private static void Main(string[] args)
    {
        CustomerManager customerManager = new CustomerManager();
        customerManager.CreditCaculatorBase = new After2010CreditCalculator();
        customerManager.SaveCredit();
        Console.WriteLine("Hello, World!");
    }
}

abstract class CreditCaculatorBase
{
    public abstract void Calculate();
}

class Befor2010CreditCalculator : CreditCaculatorBase
{
    public override void Calculate()
    {
        Console.WriteLine("Credit calculated using befor2010");
    }
}

class After2010CreditCalculator : CreditCaculatorBase
{
    public override void Calculate()
    {
        Console.WriteLine("Credit calculated using after2010");

    }
}



class CustomerManager
{


    public CreditCaculatorBase CreditCaculatorBase { get; set; }
    public void SaveCredit()
    {
        Console.WriteLine("Customer manager busines");
        CreditCaculatorBase.Calculate();
    }
}