namespace ConsoleApp1Tests.MessageFeat;

public class MessageTests
{
    [Fact]
    public void TestHelloMessage()
    {
        var message = new Message();

        var actual = message.HelloMessage("Test");

        actual.Should().Be("Привет, Test!");
    }

    [Fact]
    public void TestByeMessage()
    {
        var message = new Message();

        var actual = message.ByeMessage();

        actual.Should().Be("До связи!");
    }
}