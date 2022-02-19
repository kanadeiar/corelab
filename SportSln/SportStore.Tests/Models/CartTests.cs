namespace SportStore.Tests.Models;

public class CartTests
{
    [Fact]
    public void AddItem_CorrectCall_ShouldCanAddNewValues()
    {
        var p1 = new Product { Id = 1, Name = "P1" };
        var p2 = new Product { Id = 2, Name = "P2" };
        var target = new Cart();

        target.AddItem(p1, 1);
        target.AddItem(p2, 1);
        var results = target.Lines.ToArray();

        Assert.Equal(2, results.Count());
        Assert.Equal(p1, results[0].Product);
        Assert.Equal(p2, results[1].Product);
    }
    [Fact]
    public void AddItem_ExistsElement_ShouldAddQuantity()
    {
        var p1 = new Product { Id = 1, Name = "P1" };
        var p2 = new Product { Id = 2, Name = "P2" };
        var target = new Cart();

        target.AddItem(p1, 1);
        target.AddItem(p2, 1);
        target.AddItem(p1, 9);
        var results = target.Lines.ToArray();

        Assert.Equal(2, results.Count());
        Assert.Equal(10, results[0].Quantity);
        Assert.Equal(1, results[1].Quantity);
    }
    [Fact]
    public void RemoveLine_CorrectRemove_ShouldRemovedLine()
    {
        var p1 = new Product { Id = 1, Name = "P1" };
        var p2 = new Product { Id = 2, Name = "P2" };
        var p3 = new Product { Id = 3, Name = "P3" };
        var target = new Cart();

        target.AddItem(p1, 1);
        target.AddItem(p2, 3);
        target.AddItem(p3, 5);
        target.RemoveLine(p2);

        Assert.Empty(target.Lines.Where(c => c.Product == p2));
        Assert.Equal(2, target.Lines.Count());
    }
    [Fact]
    public void AddItem_Correct_ShouldCorrectCalculateCartTotal()
    {
        var p1 = new Product { Id = 1, Name = "P1", Price = 100M };
        var p2 = new Product { Id = 2, Name = "P2", Price = 50M };
        var target = new Cart();

        target.AddItem(p1, 1);
        target.AddItem(p2, 1);
        target.AddItem(p1, 3);
        var result = target.ComputeTotalValue();

        Assert.Equal(450M, result);
    }
    [Fact]
    public void AddItem_CorrectClear_ShouldCleared()
    {
        var p1 = new Product { Id = 1, Name = "P1" };
        var p2 = new Product { Id = 2, Name = "P2" };
        var target = new Cart();

        target.AddItem(p1, 1);
        target.AddItem(p2, 1);
        target.Clear();

        Assert.Empty(target.Lines);
    }
}