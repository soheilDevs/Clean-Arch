namespace Domain.Orders;

public interface IOrderRepository
{
    List<Order> GetList();
    Order GetById(long id);
    void Add(Order order);
    void Update(Order order);
    void SaveChanges();
}