using MediatR;
using Query.Models.Product;
using Query.Products.DTOs;

namespace Query.Products.GetList;

public record GetProductListQuery:IRequest<List<ProductReadModel>>;