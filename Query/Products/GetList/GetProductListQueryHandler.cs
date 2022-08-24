using InfraStructure.Persistent.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Query.Models.Product;
using Query.Products.DTOs;

namespace Query.Products.GetList;

public class GetProductListQueryHandler:IRequestHandler<GetProductListQuery,List<ProductReadModel>>
{
    //private readonly AppDbContext _context;
    private readonly IProductReadRepository _readRepository;

    public GetProductListQueryHandler(IProductReadRepository readRepository)
    {
        _readRepository = readRepository;
    }
    public async Task<List<ProductReadModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        //return await _context.Products.Include(c=>c.Images)
        //    .Select(product => ProductMapper.MapProductToDto(product)).ToListAsync();
        return await _readRepository.GetAll();
    }
}