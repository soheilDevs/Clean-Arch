using Domain.ProductAgg;
using MongoDB.Driver;
using Query.Models.Product;
using Query.Shared.Repository;

namespace Query.Repositories;

public class ProductReadRepository : BaseReadRepository<ProductReadModel>, IProductReadRepository
{
    public ProductReadRepository(IMongoClient client) : base(client)
    {

    }
}