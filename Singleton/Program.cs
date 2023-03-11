internal class Program
{
    private static void Main(string[] args)
    {
        var customerManager = CustomerManager.CreateAsSingleton();
        customerManager.Save();


    }
}
class CustomerManager
{
    static CustomerManager _customerManager;
    static object _lockerObject = new object();
    private CustomerManager()
    {

    }
    public static CustomerManager CreateAsSingleton()
    {
        //if (_customerManager == null)
        //{
        //    _customerManager = new CustomerManager();
        //}
        //return _customerManager;
        //return _customerManager ?? (_customerManager=new CustomerManager()); 
        //bu sekildede yapilabilir.
        lock (_lockerObject)
        {
            if (_customerManager == null)
            {
                _customerManager = new CustomerManager();
            }
        }
        return _customerManager;
    }

    public void Save()
    {
        Console.WriteLine("Saved!!!");
    }
}