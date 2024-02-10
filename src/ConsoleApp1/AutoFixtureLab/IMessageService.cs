namespace ConsoleApp1.AutoFixtureLab;

public interface IMessageService
{
    string Name { get; set; }
    Task<string> SendMessage(string message);
}