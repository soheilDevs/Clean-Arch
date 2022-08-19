using Domain.OrderAgg.Services;
using Domain.Products;

namespace Application.Orders.Services;

public class OrderDomainService:IOrderDomainService
{
    private readonly IProductRepository _productRepository;

    public OrderDomainService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public bool IsProductNotExist(Guid productId)
    {
        var productIsExist = _productRepository.IsProductExist(productId);

        return !productIsExist;
    }
}