namespace ConsoleApp1.SenderModule.MessageFeat;

public class Message
{
    public string HelloMessage(string name)
    {
        var text = $"Привет, {name}!";

        return text;
    }

    public string ByeMessage()
    {
        return "До связи!";
    }
}