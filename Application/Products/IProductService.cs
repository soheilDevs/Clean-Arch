using Application.Orders.DTOs;
using Application.Products.DTOs;

namespace Application.Products;

public interface IProductService
{
    void AddProduct(AddProductDto command);
    void EditProduct(EditProductDto command);
    ProductDto GetProductById(long productId);
    List<ProductDto> GetProducts();
}