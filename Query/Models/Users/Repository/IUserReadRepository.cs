using Query.Shared.Repository;

namespace Query.Models.Users.Repository;

public interface IUserReadRepository:IBaseReadRepository<UserReadModel>
{
    Task<UserReadModel> GetByEmail(string email);
}