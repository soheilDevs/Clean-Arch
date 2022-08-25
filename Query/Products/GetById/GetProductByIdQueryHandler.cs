using InfraStructure.Persistent.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Query.Models.Product;
using Query.Models.Product.Repository;
using Query.Products.DTOs;

namespace Query.Products.GetById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadModel>
{
    //private readonly AppDbContext _context;
    private readonly IProductReadRepository _readRepository;

    public GetProductByIdQueryHandler(IProductReadRepository readRepository)
    {
        _readRepository = readRepository;
    }
    public async Task<ProductReadModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        //var product =await _context.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);
        //return ProductMapper.MapProductToDto(product);

        return await _readRepository.GetById(request.ProductId);
    }
}