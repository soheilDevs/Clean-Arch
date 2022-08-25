namespace Domain.Users;

public interface IUserDomainService
{
    public bool EmailIsExist(string email);

}