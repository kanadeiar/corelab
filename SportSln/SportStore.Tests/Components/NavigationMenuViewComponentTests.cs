namespace SportStore.Tests.Components;

public class NavigationMenuViewComponentTests
{
    [Fact]
    public void Invoke_CorrectRequest_ShouldCorrectSelectCategories()
    {
        var repositoryFake = new Mock<IStoreRepository>();
        var products = new Product[] {
            new Product { Id = 1, Name = "P1", Category = "Applies" },
            new Product { Id = 2, Name = "P2", Category = "Applies" },
            new Product { Id = 3, Name = "P3", Category = "Plums" },
            new Product { Id = 4, Name = "P4", Category = "Oranges" },
        }.AsQueryable();
        repositoryFake.Setup(m => m.Products).Returns(products);
        var target = new NavigationMenuViewComponent(repositoryFake.Object);

        var results = (target.Invoke() as ViewViewComponentResult).ViewData.Model;

        var actual = (results as IEnumerable<string>).ToArray();
        Assert.True(Enumerable.SequenceEqual(new string[] { "Applies", "Oranges", "Plums" }, actual));
    }
    [Fact]
    public void Invoke_CorrectCategoryRequest_ShouldIndicateSelectedCategory()
    {
        var expectedCategory = "Applies";
        var repositoryFake = new Mock<IStoreRepository>();
        var products = new Product[] {
            new Product { Id = 1, Name = "P1", Category = "Applies" },
            new Product { Id = 2, Name = "P2", Category = "Oranges" },
        }.AsQueryable();
        repositoryFake.Setup(m => m.Products).Returns(products);
        var target = new NavigationMenuViewComponent(repositoryFake.Object);
        target.ViewComponentContext = new ViewComponentContext
        {
            ViewContext = new Microsoft.AspNetCore.Mvc.Rendering.ViewContext
            {
                RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
            }
        };
        target.RouteData.Values["category"] = expectedCategory;

        var result = (target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

        Assert.Equal(expectedCategory, result);
    }
}