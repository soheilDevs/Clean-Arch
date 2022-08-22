using MediatR;
using Query.Products.DTOs;

namespace Query.Products.GetList;

public record GetProductListQuery:IRequest<List<ProductDto>>;