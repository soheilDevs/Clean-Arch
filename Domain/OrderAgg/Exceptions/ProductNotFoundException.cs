using Domain.Shared.Exceptions;

namespace Domain.OrderAgg.Exceptions;

public class ProductNotFoundException:BaseDomainException
{
    public ProductNotFoundException():base("Product Not Found")
    {
        
    }
}