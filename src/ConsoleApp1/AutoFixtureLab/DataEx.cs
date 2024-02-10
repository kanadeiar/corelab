namespace ConsoleApp1.AutoFixtureLab;

public class DataEx
{
    private readonly IMessageService _service;

    public DataEx(IMessageService service)
    {
        _service = service;
    }

    public async Task<string> GetMessage(string text)
    {
        return await _service.SendMessage(text);
    }
}