using Domain.Shared;

namespace Domain.ProductAgg;

public class ProductImages:BaseEntity
{
    public ProductImages(Guid productId, string imageName)
    {
        if (string.IsNullOrWhiteSpace(imageName))
        {
            throw new Exception("dada");
        }
        ProductId = productId;
        ImageName = imageName;
    }

    public Guid ProductId { get;private set; }
    public long Id { get;private set; }
    public string ImageName { get;private set; }
}