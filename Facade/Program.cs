internal class Program
{
    private static void Main(string[] args)
    {
        CustomerManager customerManager = new CustomerManager();
        customerManager.Save();
        Console.WriteLine("Hello, World!");
    }
}


class Logging : ILogging
{
    public void Log()
    {
        Console.Write("Logged.");
    }
}
public interface ILogging
{
    void Log();
}



class Caching : ICaching
{
    public void Cache()
    {
        Console.WriteLine("Cached");
    }
}

interface ICaching
{
    void Cache();
}


class Authorize : IAuthorize
{
    public void CheckUser()
    {
        Console.WriteLine("User checked");
    }
}
public interface IAuthorize
{
    void CheckUser();
}


public class Validation : IValidate
{
    public void Validate()
    {
        Console.WriteLine("Validation  checked");
    }
}

interface IValidate
{
    void Validate();
}






class CustomerManager
{

    CrossCuttingConcernsFacade _concerns;
    public CustomerManager()
    {
        _concerns = new CrossCuttingConcernsFacade();

    }

    public void Save()
    {
        _concerns.Caching.Cache();
        _concerns.Authorize.CheckUser();
        _concerns.Logging.Log();
        _concerns.Validate.Validate();

        Console.WriteLine("Kayit yapildi.");
    }
}

class CrossCuttingConcernsFacade
{
    public ILogging Logging;
    public ICaching Caching;
    public IAuthorize Authorize;
    public IValidate Validate;
    public CrossCuttingConcernsFacade()
    {
        Logging = new Logging();
        Caching = new Caching();
        Authorize = new Authorize();
        Validate = new Validation();
    }
}