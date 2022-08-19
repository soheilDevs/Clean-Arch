using Domain.User.ValueObjects;
using Domain.Users.ValueObjects;

namespace Domain.Users;

public class User
{
    public User(string name, string family, PhoneBook phoneBook)
    {
        Name = name;
        Family = family;
        PhoneBook = phoneBook;
    }
    public string Name { get;private set; }
    public string Family { get; private set; }
    public PhoneBook PhoneBook { get; private set; }
}