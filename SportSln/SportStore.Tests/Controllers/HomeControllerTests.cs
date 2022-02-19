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

        var result = (contoller.Index() as ViewResult).ViewData.Model as ProductListWebModel;

        var actual = result.Products.ToArray();
        Assert.True(actual.Count() == contoller.PageSize);
        Assert.Equal("P1", actual[0].Name);
        Assert.Equal("P2", actual[1].Name);
    }
    [Fact]
    public void Index_CorrectRequest_ShouldCanPaginate()
    {
        var repositoryFake = new Mock<IStoreRepository>();
        var products = Enumerable.Range(1, 5).Select(x => new Product
        {
            Id = x,
            Name = $"P{x}",
        }).AsQueryable();
        repositoryFake.Setup(m => m.Products).Returns(products);
        var contoller = new HomeController(repositoryFake.Object) { PageSize = 3 };

        var result = (contoller.Index(2) as ViewResult).ViewData.Model as ProductListWebModel;

        var actual = result.Products.ToArray();
        Assert.True(actual.Count() == 2);
        Assert.Equal("P4", actual[0].Name);
        Assert.Equal("P5", actual[1].Name);
    }
    [Fact]
    public void Inxex_CorrectRequest_ShouldCanSendPaginationWebModel()
    {
        var repositoryFake = new Mock<IStoreRepository>();
        var products = Enumerable.Range(1, 5).Select(x => new Product
        {
            Id = x,
            Name = $"P{x}",
        }).AsQueryable();
        repositoryFake.Setup(m => m.Products).Returns(products);
        var contoller = new HomeController(repositoryFake.Object) { PageSize = 3 };

        var result = (contoller.Index(2) as ViewResult).ViewData.Model as ProductListWebModel;

        var pagingInfo = result.PagingInfo;
        Assert.Equal(2, pagingInfo.CurrentPage);
        Assert.Equal(3, pagingInfo.ItemsPerPage);
        Assert.Equal(5, pagingInfo.TotalItems);
        Assert.Equal(2, pagingInfo.TotalPages);
    }
}