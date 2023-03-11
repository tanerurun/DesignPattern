internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

abstract class MessageManagerBase
{
    public void Save()
    {
        Console.WriteLine("Message saved.");
    }
    public abstract void Send(Body body);

}

class Body
{
    public string Title { get; set; }
    public string Text { get; set; }
}
class MailSender : MessageManagerBase
{
    public override void Send(Body body)
    {
        Console.WriteLine("{0} was sent via Mail Sent", body);
    }
}

class SmsSender : MessageManagerBase
{
    public override void Send(Body body)
    {
        Console.WriteLine("{1} was sent Sms ", body);
    }
}