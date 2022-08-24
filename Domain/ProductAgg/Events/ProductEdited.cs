using Domain.Shared;

namespace Domain.ProductAgg.Events;

public class ProductEdited:BaseDomainEvent
{
    public long ProductId { get; set; }
    public string Name { get; set; }
}