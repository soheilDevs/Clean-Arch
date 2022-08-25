using MediatR;
using Query.Models.Users;

namespace Query.Users.GetByEmail;

public record GetUserByEmailQuery(string Email):IRequest<UserReadModel>;