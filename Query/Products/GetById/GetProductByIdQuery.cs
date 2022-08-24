using MediatR;
using Query.Models.Product;
using Query.Products.DTOs;

namespace Query.Products.GetById;

public record GetProductByIdQuery(long ProductId):IRequest<ProductReadModel>;