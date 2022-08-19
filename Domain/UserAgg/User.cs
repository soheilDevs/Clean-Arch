using Domain.Shared;
using Domain.User.ValueObjects;
using Domain.UserAgg.Events;
using Domain.Users.ValueObjects;

namespace Domain.Users;

public class User:AggregateRoot
{
    public User(string name, string family, PhoneBook phoneBook, string email)
    {
        Name = name;
        Family = family;
        PhoneBook = phoneBook;
        Email = email;
    }
    public string Name { get;private set; }
    public string Email { get;private set; }
    public string Family { get; private set; }
    public PhoneBook PhoneBook { get; private set; }

    public static User Register(string email)
    {
        var user = new User("", "", null, email);
        user.AddDomainEvent(new UserRegistered(user.Id,email));
        return user;
    }
}
