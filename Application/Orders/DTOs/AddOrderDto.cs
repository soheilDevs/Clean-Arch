namespace Application.Orders.DTOs;

public class OrderDto     //baraye return kardan mibashad
{
    public long UserId { get; set; }
    public long Id { get;  set; }
    public long ProductId { get;  set; }
    public int Count { get;  set; }
    public int Price { get; set; }
}
public class AddOrderDto
{
    public AddOrderDto(long productId, int count, int price)
    {
        ProductId = productId;
        Count = count;
        Price = price;
    }
    public long ProductId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
}

public class FinallyOrderDto
{
    public FinallyOrderDto(long orderId)
    {
        OrderId = orderId;
    }
    public long OrderId { get; set; }
}