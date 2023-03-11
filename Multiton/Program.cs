internal class Program
{
    private static void Main(string[] args)
    {

        Camera camera1 = Camera.GetCamera("NIKON1");
        Camera camera2 = Camera.GetCamera("NIKON1");

        Camera camera3 = Camera.GetCamera("NIKON4");
        Camera camera4 = Camera.GetCamera("NIKON4");
        Camera camera5 = Camera.GetCamera("NIKON4");

        Console.WriteLine(camera1.Id);
        Console.WriteLine(camera2.Id);

        Console.WriteLine(camera3.Id);

        Console.WriteLine(camera4.Id);

        Console.WriteLine(camera5.Id);




    }
}

class Camera
{
    static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
    static object _lock = new object();

    private string brand;
    public Guid Id { get; set; }
    private Camera()
    {
        Id = Guid.NewGuid();

    }
    public static Camera GetCamera(string brand)
    {
        lock (_lock)
        {
            if (!_cameras.ContainsKey(brand))
            {
                _cameras.Add(brand, new Camera());
            }
        }
        return _cameras[brand];
    }
}
