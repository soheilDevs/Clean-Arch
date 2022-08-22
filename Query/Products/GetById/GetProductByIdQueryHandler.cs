using InfraStructure.Persistent.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Query.Products.DTOs;

namespace Query.Products.GetById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly AppDbContext _context;

    public GetProductByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product =await _context.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);
        return ProductMapper.MapProductToDto(product);
    }
}