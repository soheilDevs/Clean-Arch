using Domain.Shared;

namespace Domain.ProductAgg;

public class ProductImages:BaseEntity
{
    public ProductImages(long productId, string imageName)
    {
        if (string.IsNullOrWhiteSpace(imageName))
        {
            throw new Exception("dada");
        }
        ProductId = productId;
        ImageName = imageName;
    }

    public long ProductId { get;private set; }
    public string ImageName { get;private set; }
}