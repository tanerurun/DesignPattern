internal class Program
{
    private static void Main(string[] args)
    {
        CustomerManager customerManager = new CustomerManager(StubLogger
            .GetLogger());

        customerManager.Save();
    }
}

public class CustomerManager
{
    private ILogger _logger;

    public CustomerManager(ILogger logger)
    {
        _logger = logger;
    }
    public void Save()
    {
        Console.WriteLine("Saved");
        _logger.Log();
    }
}
public interface ILogger
{
    void Log();
}

public class Log4NetLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("logged with Log4NetLogger ");
    }
}

public class NLogLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("NLogLogger ");

    }
}


class StubLogger : ILogger
{
    private static StubLogger _stubLogger;
    private static object _lock = new object();


    private StubLogger() { }

    public static StubLogger GetLogger()
    {
        lock (_lock)
        {
            if (_stubLogger == null)
            {
                _stubLogger = new StubLogger();
            }
        }

        return _stubLogger;
    }
    public void Log()
    {

    }
}
public class CustomerManagerTests
{
    public void Test()
    {
        CustomerManager customer = new CustomerManager(StubLogger.GetLogger());
        customer.Save();
    }
}