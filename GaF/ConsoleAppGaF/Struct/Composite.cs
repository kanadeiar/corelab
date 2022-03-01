namespace ConsoleAppGaF.Struct;

interface IComponent
{
    public string Operation();
    public virtual void Add(IComponent component) => throw new NotImplementedException();
    public virtual void Remove(IComponent component) => throw new NotImplementedException();
    public virtual bool IsComposite() => true;
}
class Leaf : IComponent
{
    public string Operation()
    {
        return "Leaf";
    }
    public bool IsComposite()
    {
        return false;
    }
}
class Composite : IComponent
{
    protected List<IComponent> _children = new List<IComponent>();
    public void Add(IComponent component)
    {
        _children.Add(component);
    }
    public void Remove(IComponent component)
    {
        _children.Remove(component);
    }
    public string Operation()
    {
        int i = 0;
        string result = "Branch( ";
        foreach (var component in _children)
        {
            result += component.Operation();
            if (i != _children.Count - 1)
            {
                result += " + ";
            }
            i++;
        }
        return result + " )";
    }
}
