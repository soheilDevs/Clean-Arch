using Domain.ProductAgg;
using Domain.ProductAgg.Events;
using Domain.Products;
using Domain.Shared;
using Domain.Shared.Exceptions;
using MediatR;

namespace Application.Products.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,long>
{
    private readonly IProductRepository _repository;
    private readonly IMediator _mediator;
    public CreateProductCommandHandler(IProductRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }
    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //var validator = new CreateProductCommandValidator();
        //var checker = validator.Validate(request);
        //if (!checker.IsValid)
        //    throw new InvalidDomainDataException(checker.Errors[0].ToString());

        var product = new Product(request.Title, Money.FromToman(request.Price), request.Description);
        _repository.Add(product);
        await _repository.SaveChanges();
        //foreach (var @event in product.DomainEvents )
        //{
        //  await  _mediator.Publish(@event);
        //}
        await _mediator.Publish(new ProductCreated(product.Id, product.Title));
        return product.Id;
    }
}