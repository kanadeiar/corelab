using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace MauiApp1.Views;

public partial class QuestionPage : ContentPage
{
    public QuestionPage()
	{
		InitializeComponent();
	}

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            var name = NameEntry.Text;
            var idea = IdeaEditor.Text;
            if (string.IsNullOrEmpty(name))
            {
                DisplayAlert("Недостаточно данных", "Пожалуйста, введите свое имя", "OK");
                SendButton.Text = "Отправить";
                SendButton.IsEnabled = true;
                return;
            }

            if (string.IsNullOrEmpty(idea))
            {
                DisplayAlert("Недостаточно данных", "Введите описание своей идеи", "OK");
                SendButton.Text = "Отправить";
                SendButton.IsEnabled = true;
                return;
            }

            var address = "smtp.yandex.ru";
            var port = 587;
            var useSsl = true;
            var login = "kanadeiar";
            var password = "wzendjlmrxpxmnwn";

            var from = "kanadeiar@yandex.ru";
            //var to = "kanadeiar@gmail.com";
            var to = "nikitin@nsoil.ru";
            var subject = "Тестирование";

            var text = $"Имя автора идеи: {name}\nОписание идеи:\n{idea}";

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

            DisplayAlert("Выполнено", "Сообщение отправлено", "OK");
            NameEntry.Text = string.Empty;
            IdeaEditor.Text = string.Empty;
        }
        catch (Exception ex)
        {
            DisplayAlert("Ошибка", "Не удалось отправить сообщение. Ошибка: " + ex, "OK");
        }
    }
}