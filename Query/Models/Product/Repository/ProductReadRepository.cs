using MongoDB.Driver;
using Query.Shared.Repository;

namespace Query.Models.Product.Repository;

public class ProductReadRepository: BaseReadRepository<ProductReadModel>, IProductReadRepository
{
    public ProductReadRepository(IMongoClient client) : base(client)
    {
    }
}