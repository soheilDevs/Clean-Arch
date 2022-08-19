using Domain.Orders;

namespace InfraStructure.Persistent.Memory.Orders;

public class OrderRepository:IOrderRepository
{
    private Context _context;

    public OrderRepository(Context context)
    {
        _context = context;
    }
    public List<Order> GetList()
    {
        return _context.Orders;
    }

    public Order GetById(long id)
    {
        return _context.Orders.FirstOrDefault(f => f.Id == id);
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public void Update(Order order)
    {
        var olderOrder = GetById(order.Id);
        _context.Orders.Remove(olderOrder);
        Add(order);
    }

    public void SaveChanges()
    {
        //
    }
}