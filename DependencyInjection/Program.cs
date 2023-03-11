using Ninject;

internal class Program
{
    private static void Main(string[] args)
    {
        IKernel kernel = new StandardKernel();
        kernel.Bind<IProductDal>().To<IProductDal>().InSingletonScope();


        ProductManager manager = new ProductManager(new ProductDal());
        manager.Save();

    }
}

interface IProductDal
{
    public void Save();
}

public class ProductDal : IProductDal
{
    public void Save()
    {
        Console.WriteLine("Saved with EF");
    }
}
interface IProductService
{
    public void Save();
}
class ProductManager : IProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void Save()
    {
        ProductDal productDal = new ProductDal();
        productDal.Save();
    }
}