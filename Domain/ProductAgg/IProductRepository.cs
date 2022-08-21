using Domain.ProductAgg;

namespace Domain.Products;

public interface IProductRepository
{
    List<Product> GetList();
    Task<Product> GetById(long id);
    void Add(Product product);
    void Update(Product product);
    void Remove(Product product);
    Task SaveChanges();
    bool IsProductExist(long id);
}