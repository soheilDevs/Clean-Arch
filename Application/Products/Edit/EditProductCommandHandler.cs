using Domain.Products;
using Domain.Shared;
using MediatR;

namespace Application.Products.Edit;

public class EditProductCommandHandler:IRequestHandler<EditProductCommand>
{
    private readonly IProductRepository _repository;
    private readonly IMediator _mediator;
    public EditProductCommandHandler(IProductRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id);
        product.Edit(request.Title, Money.FromToman(request.Price),request.Description);
        _repository.Update(product);
        await _repository.SaveChanges();
        foreach (var @event in product.DomainEvents)
        {
            await _mediator.Publish(@event);
        }
        return Unit.Value;
    }
}