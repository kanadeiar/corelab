using ConsoleApp1.CleanCode;
using Moq;

namespace ConsoleApp1.Tests.CleanCode;

[TestFixture]
public class SetupTeardownIncluderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestableHtml_WithAttributeTestWithSuite_ShouldCorrect()
    {
        var expectedHtml = "<html></html>";
        var pageDataMock = new Mock<IPageData>();
        pageDataMock.Setup(x => x.GetContent()).Returns("content");
        pageDataMock.Setup(x => x.GetWikiPage()).Returns(new WikiPage());
        pageDataMock.Setup(x => x.HasAttribute("test")).Returns(true);
        pageDataMock.Setup(x => x.GetHtml()).Returns(expectedHtml);

        var actual = SetupTeardownIncluder.Render(pageDataMock.Object, true);
        
        Assert.That(actual, Is.EqualTo(expectedHtml));
        pageDataMock.Verify(x => x.SetContent("!include -setup .test\n!include -setup .test\ncontent\n!include -teardown .test\n!include -teardown .test\n"));
    }

    [Test]
    public void TestableHtml_WithAttributeTestMini_ShouldCorrect()
    {
        var expectedHtml = "<html></html>";
        var pageDataMock = new Mock<IPageData>();
        pageDataMock.Setup(x => x.GetContent()).Returns("content");
        pageDataMock.Setup(x => x.GetWikiPage()).Returns(new WikiPage());
        pageDataMock.Setup(x => x.HasAttribute("test")).Returns(true);
        pageDataMock.Setup(x => x.GetHtml()).Returns(expectedHtml);

        var actual = SetupTeardownIncluder.Render(pageDataMock.Object);

        Assert.That(actual, Is.EqualTo(expectedHtml));
        pageDataMock.Verify(x => x.SetContent("!include -setup .test\ncontent\n!include -teardown .test\n"));
    }
}