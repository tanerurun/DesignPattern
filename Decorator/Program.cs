internal class Program
{
    private static void Main(string[] args)
    {
        var personelCar = new PersonalCar();
        personelCar.Make = "BMW";
        personelCar.Model = "44";
        personelCar.HirePrice = 500;

        SpecialOffer specialOffer = new SpecialOffer(personelCar);
        Console.WriteLine("Concrete :{0} ", personelCar.HirePrice);
        Console.WriteLine("SpecialOffer den gelen ", specialOffer.HirePrice);

    }
}

public abstract class CarBase
{
    public abstract string Make { get; set; }
    public abstract string Model { get; set; }
    public abstract decimal HirePrice { get; set; }
}

class PersonalCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}

class CommercialCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}

abstract class CarDecoratorBase : CarBase
{
    private CarBase _carBase;

    protected CarDecoratorBase(CarBase carBase)
    {
        _carBase = carBase;
    }

}

class SpecialOffer : CarDecoratorBase
{
    private readonly CarBase _carbase;
    public SpecialOffer(CarBase carBase) : base(carBase)
    {
        _carbase = carBase;
    }

    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice
    {
        get
        {
            return _carbase.HirePrice * 90 / 100;
        }
        set
        {
        }
    }
}