using Domain.Shared;
using Domain.User;
using Domain.User.ValueObjects;
using Domain.Users;
using Domain.Users.ValueObjects;

var money = Money.FromToman(10000);
var money2 = Money.FromToman(12000);
var money3 = money2 + money;
Console.WriteLine(money3.ToString());
Console.WriteLine(money==money2);

var user = new User("aaaa", "bbbb", new PhoneBook(new PhoneNumber("09129994444"), new PhoneNumber("09129994444")));
var user2 = new User("aaaa", "bbbb", new PhoneBook(new PhoneNumber("09129994444"), new PhoneNumber("09129994444")));
Console.WriteLine(user.PhoneBook==user2.PhoneBook);
