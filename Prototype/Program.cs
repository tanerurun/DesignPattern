internal class Program
{
    private static void Main(string[] args)
    {
        Customer customer = new Customer
        {
            FirstName = "Test",
            LastName = "Test",
            City = "Test",
            Id = 1
        };
        Console.WriteLine(customer.FirstName);
        var customer2 = (Customer)customer.Clone();
        customer2.FirstName = "Test22222";
        customer2.LastName = "Test";
        customer2.City = "Test";
        customer2.Id = 2;
        Console.WriteLine(customer2.FirstName);


    }
}

public abstract class Person
{
    public abstract Person Clone();
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}

public class Customer : Person
{
    public string City { get; set; }

    public override Person Clone()
    {
        return (Person)MemberwiseClone();
    }
}

public class Employee : Person
{
    public decimal Salary { get; set; }

    public override Person Clone()
    {
        return (Person)MemberwiseClone();
    }
}