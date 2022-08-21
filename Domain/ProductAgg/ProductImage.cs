using Domain.Shared;
using Domain.Shared.Exceptions;

namespace Domain.ProductAgg;

public class ProductImage:BaseEntity
{
    public ProductImage(long productId, string imageName)
    {
       NullOrEmptyDomainDataException.CheckString(imageName,"imageName");
        ProductId = productId;
        ImageName = imageName;
    }

    public long ProductId { get;private set; }
    public string ImageName { get;private set; }
}