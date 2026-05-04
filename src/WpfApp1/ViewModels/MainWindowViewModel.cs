using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels;

public class MainWindowViewModel : Base.ViewModelBase
{
    public string Name
    {
        get;
        set => Set(ref field, value);
    } = string.Empty;

    public string Idea
    {
        get;
        set => Set(ref field, value);
    } = string.Empty;

    public string Title
    {
        get;
        init => Set(ref field, value);
    } = "Опытное приложение - опросник";

    /// <summary>
    /// Отправить сведения из опроса
    /// </summary>
    public ICommand SendAppCommand => field ??=
        new LambdaCommand(OnSendAppCommandExecuted, CanSendAppComandExecute);
    private bool CanSendAppComandExecute(object? p) => string.IsNullOrEmpty(Name) == false && string.IsNullOrEmpty(Idea) == false;
    private void OnSendAppCommandExecuted(object? p)
    {
        try
        {
            var address = "smtp.yandex.ru";
            var port = 587;
            var useSsl = true;
            var login = "kanadeiar";
            var password = "wzendjlmrxpxmnwn";

            var from = "kanadeiar@yandex.ru";
            //var to = "kanadeiar@gmail.com";
            var to = "nikitin@nsoil.ru";
            var subject = "Тестирование";

            var text = $"Имя автора идеи: {Name}\nОписание идеи:\n{Idea}";

            var tMessage = new MailMessage(from, to)
            {
                Subject = subject,
                Body = text,
            };
            var client = new SmtpClient(address, port)
            {
                EnableSsl = useSsl,
                Credentials = new NetworkCredential(login, password),
            };

            client.Send(tMessage);

            MessageBox.Show("Сообщение успешно отправлено.", "Выполнено");
            Name = Idea = string.Empty;
        }
        catch (Exception e)
        {
            MessageBox.Show("Ошибка отправки сообщения: " + e, "Ошибка");
        }
    }

    /// <summary>
    /// Закрыть приложение
    /// </summary>
    public ICommand CloseAppCommand => field ??=
        new LambdaCommand(OnCloseAppCommandExecuted);
    private void OnCloseAppCommandExecuted(object? p)
    {
        Application.Current.Shutdown();
    }

    /// <summary>
    /// Сведения о программе
    /// </summary>
    public ICommand AboutAppCommand => field ??=
        new LambdaCommand(OnAboutAppCommandExecuted);
    private void OnAboutAppCommandExecuted(object? p)
    {
        MessageBox.Show("Опытное приложение - опросник.", "О программе ...");
    }
}