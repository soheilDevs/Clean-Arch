using Domain.Orders;
using Domain.ProductAgg;
using Domain.Products;

namespace InfraStructure.Persistent.Memory;

public class Context
{
    public List<Product> Products { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>() {new Order(Guid.NewGuid(), 1, 1000)};
}