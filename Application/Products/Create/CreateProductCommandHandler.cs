using Domain.ProductAgg;
using Domain.Products;
using Domain.Shared;
using MediatR;

namespace Application.Products.Create;

public class CreateProductCommandHandler:IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Title, Money.FromToman(request.Price),request.Description);
        _repository.Add(product);
       await _repository.SaveChanges();

        return await Unit.Task;
    }
}