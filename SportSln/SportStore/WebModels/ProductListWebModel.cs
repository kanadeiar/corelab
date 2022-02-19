namespace SportStore.WebModels;

public class ProductListWebModel
{
    public IEnumerable<Product> Products { get; set; }
    public PagingInfoWebModel PagingInfo { get; set; }
}