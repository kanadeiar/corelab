namespace ConsoleApp1.SenderModule.MessageFeat;

public interface IMessageBuilder
{
    string GetMessage(string text);
    string ClientName { get; }
}