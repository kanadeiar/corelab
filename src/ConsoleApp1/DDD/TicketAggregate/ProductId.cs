namespace ConsoleApp1.DDD.TicketAggregate;

public record ProductId(int Id);

public class Product(ProductId id)
{
    private ProductId _id = id;

    
}