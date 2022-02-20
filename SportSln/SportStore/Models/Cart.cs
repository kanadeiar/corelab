namespace SportStore.Models;

public class Cart
{
    public IList<CartLine> Lines { get; set; } = new List<CartLine>();
    public virtual void AddItem(Product product, int quantity)
    {
        var line = Lines.FirstOrDefault(x => x.Product.Id == product.Id);
        if (line is null)
        {
            Lines.Add(new CartLine { Product = product, Quantity = quantity });
        }
        else
        {
            line.Quantity += quantity;
        }
    }
    public virtual void RemoveLine(Product product)
    {
        Lines.Remove(Lines.Single(x => x.Product.Id == product.Id));
    }
    public virtual decimal ComputeTotalValue()
    {
        return Lines.Sum(x => x.Product.Price * x.Quantity);
    }
    public virtual void Clear()
    {
        Lines.Clear();
    }
}
public class CartLine
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}