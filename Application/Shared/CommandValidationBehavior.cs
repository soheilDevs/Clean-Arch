using System.Text;
using Application.Products.Create;
using FluentValidation;
using MediatR;

namespace Application.Shared;

public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var errors = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(r => r != null);
        if (errors.Any())
        {
            var stringBuilder = new StringBuilder();
            foreach (var error in errors)
            {
                stringBuilder.AppendLine(error.ErrorMessage);
            }
            throw new InvalidCommandException(stringBuilder.ToString());
        }
        var response = await next();

        return response;
    }
}