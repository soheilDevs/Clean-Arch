using Query.Models.Users;
using Query.Models.Users.Repository;

namespace Query.Users.GetByEmail;

public class GetUserByEmailQueryHandler
{
    private readonly IUserReadRepository _readRepository;

    public GetUserByEmailQueryHandler(IUserReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<UserReadModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _readRepository.GetByEmail(request.Email);
    }
}