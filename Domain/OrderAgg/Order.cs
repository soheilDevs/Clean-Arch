using Domain.OrderAgg;
using Domain.OrderAgg.Services;
using Domain.Shared;

namespace Domain.Orders;

public class Order
{
    public long Id { get;private set; }
    public Guid ProductId { get;private set; }
   
    public int TotalPrice ;
    public int TotalItems { get; set; }
    public bool IsFinally { get; private set; }
    public DateTime FinallyDate { get; private set; }
    public ICollection<OrderItem> Items { get; private set; }
    public Order (Guid productId, int count, Money price)
    {
        if (count < 1)
            throw new ArgumentException();

        ProductId = productId;
    }
    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }

    public void AddItem(Guid productId, int count, int price,IOrderDomainService orderService)
    {
        if (orderService.IsProductNotExist(productId))
            throw new Exception("dada");
        if(Items.Any(p=>p.ProductId==productId))
            return;
        Items.Add(new OrderItem(Id,count,productId,Money.FromToman(price)));
        TotalItems += count;
    }
    public void RemoveItem(Guid productId)
    {
        var item = Items.FirstOrDefault(f => f.ProductId == productId);
        if (item == null)
            throw new Exception("dada");

        Items.Remove(item);
        TotalItems -= item.Count;
    }
}