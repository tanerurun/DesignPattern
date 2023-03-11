internal class Program
{
    private static void Main(string[] args)
    {
        Manager manager = new Manager();
        manager.Name = "Taner";
        manager.Salary = 1000;
        Manager test = new Manager();
        test.Name = "Jack";
        test.Salary = 1000;

        Worker worker = new Worker();
        worker.Name = "Yusuf";
        worker.Salary = 800;
        Worker worker2 = new Worker();
        worker2.Name = "Poyraz";
        worker2.Salary = 800;

        manager.Subordinates.Add(worker);

        Console.WriteLine("Hello, World!");
    }
}

class OrganisationalStructure
{
    public EmployeeBase Employee;

    public OrganisationalStructure(EmployeeBase firstEmployeeBase)
    {
        Employee = firstEmployeeBase;
    }

    public void Accept(VisitorBase visitor)
    {
        Employee.Accept(visitor);

    }
}
abstract class EmployeeBase
{
    public abstract void Accept(VisitorBase visitor);
    public string Name { get; set; }
    public decimal Salary { get; set; }

}

public class Manager : EmployeeBase
{
    public Manager()
    {
        Subordinates = new List<EmployeeBase>();
    }
    List<EmployeeBase> Subordinates { get; set; }
    public override void Accept(VisitorBase visitor)
    {
        visitor.Visit(this);
        foreach (var item in Subordinates)
        {
            item.Accept(visitor);
        }
    }
}

class Worker : EmployeeBase
{
    public override void Accept(VisitorBase visitor)
    {
        visitor.Visit(this);
    }
}
abstract class VisitorBase
{
    public abstract void Visit(Worker worker);
    public abstract void Visit(Manager manager);


}
class PayollVisitor : VisitorBase
{
    public override void Visit(Worker worker)
    {
        Console.WriteLine("{ß} paid {1} ", worker.Name, worker.Salary);
    }

    public override void Visit(Manager manager)
    {
        Console.WriteLine("{ß} paid {1} ", manager.Name, manager.Salary);

    }
}

class Payrise : VisitorBase
{
    public override void Visit(Worker worker)
    {
        Console.WriteLine("{0} salary increeade to {1} ", worker.Name, worker.Salary * (decimal)1.1);

    }

    public override void Visit(Manager manager)
    {
        Console.WriteLine("{0} salary increased {1} ", manager.Name, manager.Salary * (decimal)1.2);

    }
}