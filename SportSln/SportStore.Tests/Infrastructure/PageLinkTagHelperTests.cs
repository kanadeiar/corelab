namespace SportStore.Tests.Infrastructure;

public class PageLinkTagHelperTests
{
    [Fact]
    public void Generate_Correct_ShouldCanGenerate()
    {
        var urlHelper = new Mock<IUrlHelper>();
        urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
            .Returns("Test/Page1")
            .Returns("Test/Page2")
            .Returns("Test/Page3");
        var urlHelperFactory = new Mock<IUrlHelperFactory>();
        urlHelperFactory.Setup(f => f.GetUrlHelper(It.IsAny<ActionContext>()))
            .Returns(urlHelper.Object);
        var helper = new PageLinkTagHelper(urlHelperFactory.Object)
        {
            PageModel = new Models.WebModels.PagingInfoWebModel
            {
                CurrentPage = 2,
                TotalItems = 29,
                ItemsPerPage = 10,
            },
            PageAction = "Test",
        };
        var ctx = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(), "");
        var content = new Mock<TagHelperContent>();
        var output = new TagHelperOutput("div", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult(content.Object));

        helper.Process(ctx, output);

        Assert.Equal(@"<a href=""Test/Page1"">1</a>"
        + @"<a href=""Test/Page2"">2</a>"
        + @"<a href=""Test/Page3"">3</a>",
        output.Content.GetContent());
    }
}