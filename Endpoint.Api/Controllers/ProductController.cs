using Application.Products.Create;
using Application.Products.Edit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Query.Models.Product;
using Query.Products.GetById;
using Query.Products.GetList;

namespace Endpoint.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductReadModel>> GetProducts()
        {
            return await _mediator.Send(new GetProductListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ProductReadModel> GetProductById(long id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            var url = Url.Action(nameof(GetProductById), "Product", new {id = result},Request.Scheme);
            return Created(url,result);
        }
       
        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            //
            return Ok(id);
        }

    }
}
