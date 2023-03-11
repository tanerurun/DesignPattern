internal class Program
{
    private static void Main(string[] args)
    {
        Manager manager = new Manager();
        VicePresident vicePresident = new VicePresident();
        President president = new President();

        manager.SetScucessor(vicePresident);
        vicePresident.SetScucessor(president);

        Expense expense = new Expense();
        expense.Detail = "Training";
        expense.Amount = 8900;
        manager.HandleExpense(expense);

        Console.WriteLine("Hello, World!");
    }
}

class Expense
{
    public string Detail { get; set; }
    public decimal Amount { get; set; }
}

abstract class ExpensenHandlerBase
{
    protected ExpensenHandlerBase Successor;
    public abstract void HandleExpense(Expense expense);
    public void SetScucessor(ExpensenHandlerBase expensenHandlerBase)
    {
        Successor = expensenHandlerBase;

    }
}
class Manager : ExpensenHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount <= 100)
        {
            Console.WriteLine("Manager handled the expense!");
        }
        else if (Successor != null)
        {
            Successor.HandleExpense(expense);
        }

    }
}


class VicePresident : ExpensenHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 100 && expense.Amount <= 1000)
        {
            Console.WriteLine("Vice President  handled the expense!");
        }
        else if (Successor != null)
        {
            Successor.HandleExpense(expense);
        }
    }
}

class President : ExpensenHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 1000)
        {
            Console.WriteLine(" President  handled the expense!");
        }

    }
}