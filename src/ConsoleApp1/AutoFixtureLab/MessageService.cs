namespace ConsoleApp1.AutoFixtureLab;

public class MessageService : IMessageService
{
    public MessageService()
    {
        
    }

    public string Name { get; set; }

    public async Task<string> SendMessage(string message)
    {
        await Task.Delay(100);
        return "Mess: " + message;
    }
}