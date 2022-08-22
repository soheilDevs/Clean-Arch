using Domain.Products;
using Domain.Shared;
using MediatR;

namespace Application.Products.Edit;

public class EditProductCommandHandler:IRequestHandler<EditProductCommand>
{
    private readonly IProductRepository _repository;

    public EditProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id);
        product.Edit(request.Title, Money.FromToman(request.Price),request.Description);
        _repository.Update(product);
        await _repository.SaveChanges();

        return Unit.Value;
    }
}