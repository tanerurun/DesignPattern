internal class Program
{
    private static void Main(string[] args)
    {
        ProductDirector director = new ProductDirector();
        var builder = new NewCustomerProductBuilder();
        //var builder = new OldCustomerProductBuilder();
        director.GenereatedProduct(builder);
        var model = builder.GetModel();
        Console.WriteLine(model.Id);
        Console.WriteLine(model.ProductName);
        Console.WriteLine(model.Discount);
        Console.WriteLine(model.UnitPrice);


    }
}
public class ProductViewModel
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public bool DiscountApplied { get; set; }
}

public abstract class ProductBuilder
{
    public abstract void GetProductData();
    public abstract void ApplyDiscount();
    public abstract ProductViewModel GetModel();

}

public class NewCustomerProductBuilder : ProductBuilder
{
    ProductViewModel model = new ProductViewModel();


    public override void GetProductData()
    {
        model.Id = 1;
        model.CategoryName = "Test";
        model.ProductName = "Test";
        model.UnitPrice = 44;
    }
    public override void ApplyDiscount()
    {
        model.Discount = model.UnitPrice * (decimal)0.90;
        model.DiscountApplied = true;
    }

    public override ProductViewModel GetModel()
    {
        return model;
    }
}


public class OldCustomerProductBuilder : ProductBuilder
{
    ProductViewModel model = new ProductViewModel();
    public override void GetProductData()
    {
        //veritabanina baglandik varsayalim
        model.Id = 1;
        model.CategoryName = "Test";
        model.ProductName = "Test";
        model.UnitPrice = 44;
    }
    public override void ApplyDiscount()
    {
        model.Discount = model.UnitPrice * (decimal)0.90;
        model.DiscountApplied = true;
    }

    public override ProductViewModel GetModel()
    {
        return model;
    }
}

public class ProductDirector
{
    public void GenereatedProduct(ProductBuilder builder)
    {
        builder.GetProductData();
        builder.ApplyDiscount();
    }
}