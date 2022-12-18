public class Container : IContainer
{
    private readonly IDictionary<Type, Func<object>> _regs = new Dictionary<Type, Func<object>>();

    public void Register<TService, TImplementation>() where TImplementation : TService
        => _regs.Add(typeof(TService), () => Resolve(typeof(TImplementation)));
    public void Register<TService>(Func<TService> factory)
        => _regs.Add(typeof(TService), () => factory()!);
    public void RegisterInstance<TService>(TService instance)
        => _regs.Add(typeof(TService), () => instance!);
    public void RegisterSingleton<TService>(Func<TService> factory)
    {
        var lazy = new Lazy<TService>(factory);
        Register(() => lazy.Value);
    }

    public T Resolve<T>()
        => (T)Resolve(typeof(T));

    private object Resolve(Type type)
    {
        if (_regs.TryGetValue(type, out Func<object>? fac))
        {
            return fac();
        }
        else if (!type.IsAbstract)
        {
            return this.CreateInstance(type);
        }
        throw new InvalidOperationException(string.Format("No registration for {0}", type));
    }
    private object CreateInstance(Type implementationType)
    {
        var ctor = implementationType.GetConstructors().Single();
        var ctorParameters = ctor.GetParameters();
        if (!ctorParameters.Any())
        {
            return Activator.CreateInstance(implementationType)
                ?? throw new InvalidOperationException("No create instance for " + implementationType);
        }
        var dependencies = ctorParameters.Select(x => Resolve(x.ParameterType)).ToArray();
        return Activator.CreateInstance(implementationType, dependencies)
            ?? throw new InvalidOperationException("No create instance for " + implementationType);
    }
}