namespace SportStore.Tests.Controllers;

public class CartControllerTests
{
    [Fact]
    public void Index_CorrectRequest_ShouldCanLoadCart()
    {
        var p1 = new Product { Id = 1, Name = "P1" };
        var p2 = new Product { Id = 2, Name = "P2" };
        var repoFake = new Mock<IStoreRepository>();
        repoFake.Setup(_ => _.Products).Returns((new Product[] { p1, p2 }).AsQueryable());
        var cart = new Cart();
        cart.AddItem(p1, 2);
        cart.AddItem(p2, 1);
        var controller = new CartController(repoFake.Object, cart);

        var result = (controller.Index("myurl") as ViewResult).ViewData.Model as CartWebModel;

        Assert.Equal(2, result.Cart.Lines.Count());
        Assert.Equal("myurl", result.ReturnUrl);
    }
    [Fact]
    public void Index_CorrectPostRequest_ShouldCanUpdateCart()
    {
        var repoFake = new Mock<IStoreRepository>();
        repoFake.Setup(_ => _.Products).Returns((new Product[] { new Product { Id = 1, Name = "P1" } }).AsQueryable());
        var cart = new Cart();
        var controller = new CartController(repoFake.Object, cart);

        controller.Index(1, "myurl");

        Assert.Single(cart.Lines);
        Assert.Equal("P1", cart.Lines.First().Product.Name);
        Assert.Equal(1, cart.Lines.First().Quantity);
    }
}