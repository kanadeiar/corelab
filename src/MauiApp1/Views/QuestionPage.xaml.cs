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

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            var address = "";
            var port = 123;
            var useSsl = false;
            var login = "";
            var password = "";

            var from = "";
            var to = "";
            var subject = "";
            
            var name = NameEntry.Text;
            var idea = IdeaEditor.Text;
            var text = $"Имя автора идеи: {name} идея: {idea}";

            //var tMessage = new MailMessage(from, to)
            //{
            //    Subject = subject,
            //    Body = text,
            //};
            //var client = new SmtpClient(address, port)
            //{
            //    EnableSsl = useSsl,
            //    Credentials = new NetworkCredential(login, password),
            //};

            //client.Send(tMessage);

            await DisplayAlert("Выполнено", "Сообщение отправлено", "OK");
            NameEntry.Text = string.Empty;
            IdeaEditor.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", "Не удалось отправить сообщение. Ошибка: " + ex, "OK");
        }
    }
}