using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using ConsoleApp1.AutoFixtureLab;
using ConsoleApp1Tests.Infra;
using FluentAssertions;
using Moq;

namespace ConsoleApp1Tests.AutoFixtureLab;

public class PersonTests
{
    private Fixture _fixture;

    public PersonTests()
    {
        _fixture = new Fixture();
        _fixture.Customize(new AutoMoqCustomization());
    }

    [Fact]
    public async Task TestCommon()
    {
        var mock = _fixture.Freeze<Mock<IMessageService>>();
        mock.Setup(x => x.SendMessage(It.IsAny<string>())).ReturnsAsync("test");

        var data = new DataEx(mock.Object);
        var actual = await data.GetMessage("act");

        actual.Should().Be("test");
        mock.Verify(x => x.SendMessage(It.IsAny<string>()), Times.Once);
    }

    [Theory, AutoMoqData]
    public async Task TestAdvanced([Frozen]Mock<IMessageService> service, DataEx data)
    {
        service.Setup(x => x.SendMessage("act")).ReturnsAsync("test");

        var actual = await data.GetMessage("act");

        actual.Should().Be("test");
        service.Verify(x => x.SendMessage(It.IsAny<string>()), Times.Once);
    }
}
