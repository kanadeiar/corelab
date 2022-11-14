namespace Wpf.Services;

public class SampleService : ISampleService
{
    private Sample _sample;
    public SampleService()
    {
        _sample = new Sample
        {
            Id = 1,
            Name = "Тест1",
        };
    }
    public Sample GetOne()
    {
        return _sample;
    }
}
