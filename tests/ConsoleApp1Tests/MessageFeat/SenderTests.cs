namespace ConsoleApp1Tests.MessageFeat;

public class SenderTests
{
    [Theory, AutoMoqData]
    public void TestSend(MessageBuilder builder, [Frozen]Mock<IMailService> mock)
    {
        var sender = new Sender(builder, mock.Object);

        var actual = sender.Send("test@mail.ru","message");

        Assert.True(actual);
        mock.Verify(x => x.SendToMail("test@mail.ru", $"Привет, {builder.ClientName}!\nmessage\nДо связи!"), Times.Once);
    }
}