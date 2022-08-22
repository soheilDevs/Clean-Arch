using MediatR;
using Query.Products.DTOs;

namespace Query.Products.GetById;

public record GetProductByIdQuery(long ProductId):IRequest<ProductDto>;