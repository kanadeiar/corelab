public interface IContainer
{
    public void Register<TService, TImplementation>() where TImplementation : TService;
    public void Register<TService>(Func<TService> factory);
    public void RegisterInstance<TService>(TService instance);
    public void RegisterSingleton<TService>(Func<TService> factory);
    /// <summary>
    /// Получить зависимость
    /// </summary>
    public T Resolve<T>();
}
