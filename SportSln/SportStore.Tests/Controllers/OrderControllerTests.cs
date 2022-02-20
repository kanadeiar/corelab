namespace SportStore.Tests.Controllers;

public class OrderControllerTests
{
    [Fact]
    public void Checkout_EmptyCart_ShouldCannotEmptyCart()
    {
        var repoFake = new Mock<IOrderRepository>();
        var cart = new Cart();
        var order = new Order();
        var controller = new OrderController(repoFake.Object, cart);

        var result = controller.Checkout(order) as ViewResult;

        repoFake.Verify(_ => _.SaveOrder(It.IsAny<Order>()), Times.Never);
        Assert.True(string.IsNullOrEmpty(result.ViewName));
        Assert.False(result.ViewData.ModelState.IsValid);
    }
    [Fact]
    public void Checkout_InvalidRequest_ShouldCannotCheckout()
    {
        var repoFake = new Mock<IOrderRepository>();
        var cart = new Cart();
        cart.AddItem(new Product(), 1);
        var controller = new OrderController(repoFake.Object, cart);
        controller.ModelState.AddModelError("error", "error");

        var result = controller.Checkout(new Order()) as ViewResult;

        repoFake.Verify(_ => _.SaveOrder(It.IsAny<Order>()), Times.Never);
        Assert.True(string.IsNullOrEmpty(result.ViewName));
        Assert.False(result.ViewData.ModelState.IsValid);
    }
    [Fact]
    public void Checkout_CorrectRequest_ShouldCorrect()
    {
        var repoFake = new Mock<IOrderRepository>();
        var cart = new Cart();
        cart.AddItem(new Product(), 1);
        var controller = new OrderController(repoFake.Object, cart);

        var result = controller.Checkout(new Order()) as RedirectToActionResult;

        repoFake.Verify(_ => _.SaveOrder(It.IsAny<Order>()), Times.Once);
        Assert.Equal("Completed", result.ActionName);
        Assert.Equal("Order", result.ControllerName);
    }
}