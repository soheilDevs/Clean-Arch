using InfraStructure.Persistent.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Query.Products.DTOs;

namespace Query.Products.GetList;

public class GetProductListQueryHandler:IRequestHandler<GetProductListQuery,List<ProductDto>>
{
    private readonly AppDbContext _context;

    public GetProductListQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.Include(c=>c.Images)
            .Select(product => ProductMapper.MapProductToDto(product)).ToListAsync();
    }
}