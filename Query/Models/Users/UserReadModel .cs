using Query.Shared;

namespace Query.Models.Users;

public class UserReadModel:BaseReadModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Family { get; set; }
    public string Phone { get; set; }
}