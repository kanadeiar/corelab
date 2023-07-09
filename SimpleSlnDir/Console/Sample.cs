using Microsoft.Extensions.DependencyInjection;

class Sample : ISample
{
    private readonly IServiceProvider _services;
    private readonly ISecond _second;
    public Sample(IServiceProvider services)
    {
        _services = services;
        _second = _services.GetRequiredService<ISecond>();
    }
    public string GetMessage()
    {
        return _second.Message;
    }
}
