namespace SportStore.Data.Interfaces;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }
}