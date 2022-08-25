namespace Domain.Users;

public interface IUserRepository
{
    void Add(User user);
    Task<User> GetById(long id);
    Task<User> GetByEmail(string email);
    bool UserIsExist(string email);
    Task SaveChanges();
    void Update(User user);

}