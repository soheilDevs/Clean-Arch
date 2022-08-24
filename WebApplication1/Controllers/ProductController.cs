using Application.Products.Create;
using Application.Products.Edit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Query.Models.Product;
using Query.Products.DTOs;
using Query.Products.GetList;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<List<ProductReadModel>> GetProducts()
    {
        return await _mediator.Send(new GetProductListQuery());
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditProduct(EditProductCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}