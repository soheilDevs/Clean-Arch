namespace Domain.Users;

public interface IUserRepository
{
    void Add(User user);
    Task<User> GetById(long id);
    Task SaveChanges();
    void Update(User user);

}