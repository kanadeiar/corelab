namespace ConsoleApp1.MailModule;

public class MailService : IMailService
{
    public void SendToMail(string to, string message)
    {
        Console.WriteLine("На почтовый ящик {0}\nотправлено сообщение {1}", to, message);
    }
}