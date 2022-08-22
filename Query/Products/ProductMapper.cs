using Domain.ProductAgg;
using Query.Products.DTOs;

namespace Query.Products;

public class ProductMapper
{
    public static ProductDto MapProductToDto(Product product)
    {
        if (product==null)
        {
            return null;
        }
        return new ProductDto()
        {
            Description = product.Description,
            Title = product.Title,
            Images = product.Images.ToList(),
            Id = product.Id,
            Money = product.Money
        };
    }
}