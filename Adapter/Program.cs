internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EdLogger());
        productManager.Save();
        Console.WriteLine("Hello, World!");
    }
}


class ProductManager
{
    private ILogger _logger;

    public ProductManager(ILogger logger)
    {
        _logger = logger;
    }

    public void Save()
    {
        _logger.Log(" User data");
        Console.WriteLine("Save");
    }
}

interface ILogger
{
    void Log(string message);

}


class EdLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("Logged,{0}", message);
    }
}


class Log4Net
{
    public void LogMessage(string message)
    {
        Console.WriteLine("Logged with log4net", message);
    }
}


class Log4NetAdapter : ILogger
{
    public void Log(string message)
    {
        Log4Net log4Net = new Log4Net();
        log4Net.LogMessage(message);
    }
}