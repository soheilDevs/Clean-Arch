using Domain.UserAgg.Events;
using Domain.Users;
using MediatR;
using Query.Models.Users;
using Query.Models.Users.Repository;

namespace Query.EventHandlers.Users;

public class UserRegisteredEventHandler: INotificationHandler<UserRegistered>
{
    private readonly IUserReadRepository _readRepository;
    private readonly IUserRepository _writeRepository;

    public UserRegisteredEventHandler(IUserReadRepository readRepository, IUserRepository userRepository)
    {
        _readRepository = readRepository;
        _writeRepository = userRepository;
    }

    public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
    {
        var user = await _writeRepository.GetByEmail(notification.Email);
        await _readRepository.Insert(new UserReadModel()
        {
            Email = user.Email,
            CreationDate = user.CreationDate,
            Family = user.Family,
            Id = user.Id,
            Name = user.Name,
            Phone = user.PhoneNumber.Phone
        });
    }
}