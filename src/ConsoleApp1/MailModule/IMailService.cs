namespace ConsoleApp1.MailModule;

public interface IMailService
{
    void SendToMail(string to, string message);
}