using ConsoleApp1.SenderModule.MessageFeat.NamesImpl;

namespace ConsoleApp1Tests.MessageFeat;

public class SenderTests
{
    [Theory, AutoMoqData]
    public void TestSend([Frozen] NameSource source, MessageBuilder builder, [Frozen] Mock<IMailService> mock)
    {
        var sender = new Sender(builder, mock.Object);

        var actual = sender.Send("test@mail.ru", "message");

        actual.Should().BeTrue();
        mock.Verify(x => x.SendToMail("test@mail.ru", $"Привет, {source.Name}!\nmessage\nДо связи!"), Times.Once);
    }
}




