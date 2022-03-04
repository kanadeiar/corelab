namespace ConsoleAppGaF.Behavior;

class Context
{
    private State _state = null;
    public Context(State state)
    {
        TransitionTo(state);
    }
    public void TransitionTo(State state)
    {
        Console.WriteLine("Transition to {0}", state.GetType().Name);
        _state = state;
        _state.SetContext(this);
    }
    public void Request1()
    {
        _state.Handle1();
    }
}
abstract class State
{
    protected Context _context;
    public void SetContext(Context context)
    {
        _context = context;
    }
    public abstract void Handle1();
}
class ConcreteStateA : State
{
    public override void Handle1()
    {
        Console.WriteLine("ConcreteA change context");
        _context.TransitionTo(new ConcreteStateB());
    }
}
class ConcreteStateB : State
{
    public override void Handle1()
    {
        Console.WriteLine("ConcreteB handles request 1");
    }
}