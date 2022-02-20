namespace SportStore.Data.Interfaces;

public interface IOrderRepository
{
    IQueryable<Order> Orders { get; }
    void SaveOrder(Order order);
}