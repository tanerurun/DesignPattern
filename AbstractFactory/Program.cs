internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new Factory1());
        productManager.GetAll();

        Console.WriteLine("Hello, World!");
    }
}


public abstract class Logging
{
    public abstract void log(string message);
}

public abstract class Caching
{
    public abstract void Cache(string data);
}



public class Log4NetLogger : Logging
{
    public override void log(string message)
    {
        Console.WriteLine("Logged with log4Net");
    }
}

public class NLogger : Logging
{
    public override void log(string message)
    {
        Console.WriteLine("Logged with NLog");
    }
}



public class MemCache : Caching
{
    public override void Cache(string data)
    {
        Console.WriteLine("Cached with MemCache");
    }

}

public class RedisCache : Caching
{
    public override void Cache(string data)
    {
        Console.WriteLine("Cache with Redis");
    }
}


public abstract class CrossCuttingConcernsFactory
{
    public abstract Logging CreateLogger();
    public abstract Caching CreateCaching();
}


public class Factory1 : CrossCuttingConcernsFactory
{
    public override Caching CreateCaching()
    {
        return new MemCache();
    }

    public override Logging CreateLogger()
    {
        return new Log4NetLogger();
    }
}

public class Factory2 : CrossCuttingConcernsFactory
{
    public override Caching CreateCaching()
    {
        return new RedisCache();
    }

    public override Logging CreateLogger()
    {
        return new NLogger();
    }
}

public class ProductManager
{

    private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
    private Logging _logging;
    private Caching _caching;

    public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
    {
        _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
        _logging = _crossCuttingConcernsFactory.CreateLogger();
        _caching = _crossCuttingConcernsFactory.CreateCaching();
    }

    public void GetAll()
    {
        _logging.log("logged");
        _caching.Cache("Data");
        Console.WriteLine("Tum urunler listelendi.");
    }
}