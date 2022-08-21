using Domain.OrderAgg;
using Domain.ProductAgg;
using Domain.Products;

namespace InfraStructure.Persistent.Memory;

public class Context
{
    public List<Product> Products { get; set; }=new List<Product>();
    public List<Order> Orders { get; set; } = new List<Order>();
}