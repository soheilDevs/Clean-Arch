using Domain.OrderAgg;
using Domain.OrderAgg.Events;
using Domain.OrderAgg.Exceptions;
using Domain.OrderAgg.Services;
using Domain.Shared;

namespace Domain.Orders;

public class Order:AggregateRoot
{
    public long UserId { get;private set; }
    public int TotalPrice ;
    public int TotalItems { get; set; }
    public bool IsFinally { get; private set; }
    public DateTime FinallyDate { get; private set; }
    public ICollection<OrderItem> Items { get; private set; }
    public Order (long userId)
    {
        UserId=userId;
    }
    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
        AddDomainEvent(new OrderFinalized(Id,UserId));
    }

    public void AddItem(long productId, int count, int price,IOrderDomainService orderService)
    {
        if (orderService.IsProductNotExist(productId))
            throw new ProductNotFoundException();

        if(Items.Any(p=>p.ProductId==productId))
            return;
        Items.Add(new OrderItem(Id,count,productId,Money.FromToman(price)));
        TotalItems += count;
    }
    public void RemoveItem(long productId)
    {
        var item = Items.FirstOrDefault(f => f.ProductId == productId);
        if (item == null)
            throw new Exception("dada");

        Items.Remove(item);
        TotalItems -= item.Count;
    }
}