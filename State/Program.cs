internal class Program
{
    private static void Main(string[] args)
    {
        Context context = new Context();

        ModifiedState state = new ModifiedState();
        state.DoAction(context);



        Console.WriteLine("Hello, World!");
    }
}
class ModifiedState : IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("State : Modified");
        context.SetState(this);

    }
}

class DeletedState : IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("Stated : Deleted");
        context.SetState(this);
    }
}

class AddState : IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("Stated : Add");
        context.SetState(this);
    }
}
interface IState
{
    void DoAction(Context context);
}

class Context
{
    private IState _state;
    public void SetState(IState state)
    {
        _state = state;
    }

    public IState GetState()
    {
        return _state;
    }
}