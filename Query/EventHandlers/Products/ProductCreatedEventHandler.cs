using Domain.ProductAgg.Events;
using Domain.Products;
using MediatR;
using Query.Models.Product;

namespace Query.EventHandlers.Products;

public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
{
    private readonly IProductReadRepository _readRepository;
    private readonly IProductRepository _writeRepository;

    public ProductCreatedEventHandler(IProductReadRepository readRepository, IProductRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }
    public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
    {
        var product = await _writeRepository.GetById(notification.Id);
        await _readRepository.Insert(new ProductReadModel()
        {
            Id = notification.Id,
            Description = product.Description,
            Images =null,
            Title = product.Title,
            Money = product.Money,
            CreationDate = product.CreationDate,
        });
    }
}