namespace Domain.OrderAgg.Services;

public interface IOrderDomainService
{
    bool IsProductNotExist(Guid productId);
}