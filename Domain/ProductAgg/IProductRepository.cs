using Domain.ProductAgg;

namespace Domain.Products;

public interface IProductRepository
{
    List<Product> GetList();
    Product GetById(long id);
    void Add(Product product);
    void Update(Product product);
    void Remove(Product product);
    void SaveChanges();
    bool IsProductExist(long id);
}