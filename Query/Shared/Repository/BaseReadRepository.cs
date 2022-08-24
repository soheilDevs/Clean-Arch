using MongoDB.Driver;

namespace Query.Shared.Repository;

public class BaseReadRepository<TEntity>:IBaseReadRepository<TEntity> where TEntity : BaseReadModel
{
    private readonly IMongoCollection <TEntity> _collection;

    public BaseReadRepository(IMongoClient client)
    {
        var database = client.GetDatabase("Clean_Arch");
        _collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
    }
    public async Task Delete(long id)
    {
        await _collection.DeleteOneAsync(f => f.Id == id);
    }

    public async Task<List<TEntity>> GetAll()
    {
        var result = await _collection.FindAsync(r => true);
        return result.ToList();

    }

    public async Task<TEntity> GetById(long id)
    {
        var result = await _collection.FindAsync(f => f.Id == id);
        return result.FirstOrDefault();
    }

    public async Task Insert(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task Update(TEntity entity)
    {
        await _collection.ReplaceOneAsync(f=>f.Id==entity.Id,entity);
    }
}