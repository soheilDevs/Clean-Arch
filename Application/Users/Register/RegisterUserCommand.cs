using Domain.Users;
using MediatR;

namespace Application.Users.Register;

public record RegisterUserCommand(string Email,string PhoneNumber) : IRequest<long>;
public class RegisterUserCommandHandler:IRequestHandler<RegisterUserCommand,long>
{
    private readonly IUserRepository _userReposutiry;
    private readonly IUserDomainService _userDomainService;
    private readonly IMediator _mediator;

    public RegisterUserCommandHandler(IUserRepository userReposutiry, IUserDomainService userDomainService, IMediator mediator)
    {
        _userReposutiry = userReposutiry;
        _userDomainService = userDomainService;
        _mediator = mediator;
    }

    public async Task<long> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Register(request.Email, request.PhoneNumber, _userDomainService);
        _userReposutiry.Add(user);
        await _userReposutiry.SaveChanges();
        foreach (var @event in user.DomainEvents)
        {
            await _mediator.Publish(@event);
        }
        return user.Id;
    }
}