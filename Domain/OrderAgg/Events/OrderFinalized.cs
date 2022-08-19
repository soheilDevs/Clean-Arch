using Domain.Shared;

namespace Domain.OrderAgg.Events;

public class OrderFinalized:BaseDomainEvent
{
    public long OrderId { get;private set; }
    public long UserId { get;private set; }

    public OrderFinalized(long orderId, long userId)
    {
        OrderId = orderId;
        UserId = userId;
    }
}