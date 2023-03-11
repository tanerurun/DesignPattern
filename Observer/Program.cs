internal class Program
{
    private static void Main(string[] args)
    {

        ProductManager productManager = new ProductManager();
        productManager.UpdatePrice();
        Console.WriteLine("Hello, World!");
    }
}
class ProductManager
{
    List<Observer> observers = new List<Observer>();
    public void UpdatePrice()
    {
        Console.WriteLine("Product price changed.");
        Motify();
    }

    public void Attack(Observer observer)
    {
        observers.Add(observer);
    }

    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }
    private void Motify()
    {
        foreach (var item in observers)
        {
            item.Update();
        }
    }
}

abstract class Observer
{
    public abstract void Update();
}

class CustomerObserver : Observer
{
    public override void Update()
    {
        Console.WriteLine("Message to customer : Product price changed");

    }
}


class EmployeeObserver : Observer
{
    public override void Update()
    {
        Console.WriteLine("Message to employee : Product price changed");

    }
}
