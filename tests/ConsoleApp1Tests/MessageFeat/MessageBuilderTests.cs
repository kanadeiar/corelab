namespace ConsoleApp1Tests.MessageFeat;

public class MessageBuilderTests
{
    [Fact]
    public void TestAnswer()
    {
        var answerer = new MessageBuilder(new Message(), "Test");

        var actual = answerer.GetMessage("message");

        actual.Should().Be("Привет, Test!\nmessage\nДо связи!");
    }
}