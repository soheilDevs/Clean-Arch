using Domain.Shared;

namespace Domain.OrderAgg;

public class OrderItem
{
    public OrderItem(long orderId, int count, Guid productId, Money price)
    {
        OrderId = orderId;
        Count = count;
        ProductId = productId;
        Price = price;
    }

    public long Id { get;private set; }
    public long OrderId { get;protected set; }
    public int Count { get; private set; }
    public Guid ProductId { get;private set; }
    public Money Price { get; private set; }
}