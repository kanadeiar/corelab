using Microsoft.Extensions.DependencyInjection;

DependencyInjectionContainer.RegisterServices(x =>
{
    x.AddScoped<ISecond, Second>();
    x.AddScoped<ISample, Sample>();
});

DependencyInjectionContainer.Build();

IServiceProvider Services = DependencyInjectionContainer.Services;

var sample = Services.GetRequiredService<ISample>();

Console.WriteLine($"Message: {sample.GetMessage()}");

var _ = Console.ReadKey();

