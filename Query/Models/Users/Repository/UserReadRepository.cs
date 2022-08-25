using MongoDB.Driver;
using Query.Shared.Repository;

namespace Query.Models.Users.Repository;

public class UserReadRepository:BaseReadRepository<UserReadModel>,IUserReadRepository
{
    public UserReadRepository(IMongoClient client) : base(client)
    {
    }

    public async Task<UserReadModel> GetByEmail(string email)
    {
        return await _collection.Find(f => f.Email == email).FirstOrDefaultAsync();
    }
}