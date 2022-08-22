using Domain.OrderAgg;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Persistent.Ef.Orders;

public class OrderRepository:IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Order> GetById(long id)
    {
        return await _context.Orders.FirstOrDefaultAsync(f => f.Id == id);
    }

    public void Add(Order order)
    {
        _context.Add(order);
    }

    public void Update(Order order)
    {
        _context.Update(order);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}