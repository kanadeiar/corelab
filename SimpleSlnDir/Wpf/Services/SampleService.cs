namespace Wpf.Services;

public class SampleService : ISampleService
{
    private string _text;

    public SampleService(IOptions<Settings> options, ILogger<SampleService> logger)
    {
        _text = options.Value.Text;

        logger.LogInformation($"Text read from settings: '{options.Value.Text}'");
    }

    public string GetText()
    {
        return _text;
    }
}
