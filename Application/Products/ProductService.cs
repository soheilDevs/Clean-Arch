using Application.Orders.DTOs;
using Application.Products.DTOs;
using Domain.ProductAgg;
using Domain.Products;
using Domain.Shared;

namespace Application.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public void AddProduct(AddProductDto command)
    {
        _repository.Add(new Product(command.Title, Money.FromToman(command.Price)));
        _repository.SaveChanges();
    }

    public void EditProduct(EditProductDto command)
    {
        var product = _repository.GetById(command.Id);
        product.Edit(command.Title, Money.FromToman(command.Price));
        _repository.Update(product);
        _repository.SaveChanges();
    }

    public ProductDto GetProductById(long productId)
    {
        var product= _repository.GetById(productId);
        return new ProductDto()
        {
            Price = product.Money.Value,
            Title = product.Title,
            Id = productId
        };
    }

    public List<ProductDto> GetProducts()
    {
        return _repository.GetList().Select(product => new ProductDto()
        {
            Price = product.Money.Value,
            Id = product.Id,
            Title = product.Title
        }).ToList();
    }
}