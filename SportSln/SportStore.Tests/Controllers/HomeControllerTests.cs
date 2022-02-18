namespace SportStore.Tests.Controllers;

public class HomeControllerTests
{
    [Fact]
    public void Index_CorrectRequest_ShouldCanUseRepository()
    {
        var repositoryFake = new Mock<IStoreRepository>();
        var products = Enumerable.Range(1, 10).Select(x => new Product
        {
            Id = x,
            Name = $"P{x}",
        }).AsQueryable();
        repositoryFake.Setup(m => m.Products).Returns(products);
        var contoller = new HomeController(repositoryFake.Object);

        var result = (contoller.Index() as ViewResult).ViewData.Model as IEnumerable<Product>;

        var actual = result.ToArray();
        Assert.True(actual.Count() == 10);
        Assert.Equal("P1", actual[0].Name);
        Assert.Equal("P2", actual[1].Name);
    }
}