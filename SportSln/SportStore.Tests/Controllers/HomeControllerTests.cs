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

        var result = (contoller.Index(null) as ViewResult).ViewData.Model as ProductListWebModel;

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

        var result = (contoller.Index(null, 2) as ViewResult).ViewData.Model as ProductListWebModel;

        var actual = result.Products.ToArray();
        Assert.True(actual.Count() == 2);
        Assert.Equal("P4", actual[0].Name);
        Assert.Equal("P5", actual[1].Name);
    }
    [Fact]
    public void Index_CorrectRequest_ShouldCanSendPaginationWebModel()
    {
        var repositoryFake = new Mock<IStoreRepository>();
        var products = Enumerable.Range(1, 5).Select(x => new Product
        {
            Id = x,
            Name = $"P{x}",
        }).AsQueryable();
        repositoryFake.Setup(m => m.Products).Returns(products);
        var contoller = new HomeController(repositoryFake.Object) { PageSize = 3 };

        var result = (contoller.Index(null, 2) as ViewResult).ViewData.Model as ProductListWebModel;

        var pagingInfo = result.PagingInfo;
        Assert.Equal(2, pagingInfo.CurrentPage);
        Assert.Equal(3, pagingInfo.ItemsPerPage);
        Assert.Equal(5, pagingInfo.TotalItems);
        Assert.Equal(2, pagingInfo.TotalPages);
    }
    [Fact]
    public void Index_CorrectRequest_ShouldCanFilterProducts()
    {
        var repositoryFake = new Mock<IStoreRepository>();
        var products = new Product[] {
            new Product { Id = 1, Name = "P1", Category = "Cat1" },
            new Product { Id = 2, Name = "P2", Category = "Cat2" },
            new Product { Id = 3, Name = "P3", Category = "Cat1" },
            new Product { Id = 4, Name = "P4", Category = "Cat2" },
            new Product { Id = 5, Name = "P5", Category = "Cat3" },
        }.AsQueryable();
        repositoryFake.Setup(m => m.Products).Returns(products);
        var contoller = new HomeController(repositoryFake.Object) { PageSize = 3 };

        var result = (contoller.Index("Cat2", 1) as ViewResult).ViewData.Model as ProductListWebModel;

        var actual = result.Products.ToArray();
        Assert.Equal(2, actual.Length);
        Assert.True(actual[0].Name == "P2" && actual[0].Category == "Cat2");
        Assert.True(actual[1].Name == "P4" && actual[1].Category == "Cat2");
    }
    [Fact]
    public void Index_CorrectRequest_ShouldCorrectCategoryProductCount()
    {
        var repositoryFake = new Mock<IStoreRepository>();
        var products = new Product[] {
            new Product { Id = 1, Name = "P1", Category = "Cat1" },
            new Product { Id = 2, Name = "P2", Category = "Cat2" },
            new Product { Id = 3, Name = "P3", Category = "Cat1" },
            new Product { Id = 4, Name = "P4", Category = "Cat2" },
            new Product { Id = 5, Name = "P5", Category = "Cat3" },
        }.AsQueryable();
        repositoryFake.Setup(m => m.Products).Returns(products);
        var contoller = new HomeController(repositoryFake.Object) { PageSize = 3 };
        Func<ViewResult, ProductListWebModel> GetModel = result =>
            result?.ViewData?.Model as ProductListWebModel;

        int? res1 = GetModel(contoller.Index("Cat1") as ViewResult)?.PagingInfo.TotalItems;
        int? res2 = GetModel(contoller.Index("Cat2") as ViewResult)?.PagingInfo.TotalItems;
        int? res3 = GetModel(contoller.Index("Cat3") as ViewResult)?.PagingInfo.TotalItems;
        int? resAll = GetModel(contoller.Index(null) as ViewResult)?.PagingInfo.TotalItems;

        Assert.Equal(2, res1);
        Assert.Equal(2, res2);
        Assert.Equal(1, res3);
        Assert.Equal(5, resAll);
    }
}