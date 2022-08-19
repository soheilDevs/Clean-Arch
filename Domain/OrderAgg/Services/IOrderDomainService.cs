namespace Domain.OrderAgg.Services;

public interface IOrderDomainService
{
    bool IsProductNotExist(long productId);
}