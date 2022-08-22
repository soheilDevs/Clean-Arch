using Domain.Shared;
using Domain.User.ValueObjects;
using Domain.UserAgg.Events;
using Domain.Users.ValueObjects;

namespace Domain.Users;

public class User:AggregateRoot
{
    private User()
    {
        
    }
    public User(string name, string family, PhoneNumber phoneNumber, string email)
    {
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
    }
    public string Name { get;private set; }
    public string Email { get;private set; }
    public string Family { get; private set; }
    public PhoneNumber PhoneNumber { get; set; }    

    public static User Register(string email)
    {
        var user = new User("", "", null, email);
        user.AddDomainEvent(new UserRegistered(user.Id,email));
        return user;
    }
}
