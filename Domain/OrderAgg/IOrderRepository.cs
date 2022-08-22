namespace Domain.OrderAgg;

public interface IOrderRepository
{
    Task<Order> GetById(long id);
    void Add(Order order);
    void Update(Order order);
    Task SaveChanges();
}