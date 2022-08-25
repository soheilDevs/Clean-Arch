using Application.Products.Create;
using Application.Products.Edit;
using AutoMapper;
using Endpoint.Api.ViewModel.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<ProductViewModel>> GetProducts()
        {
            var products = await _mediator.Send(new GetProductListQuery());
            return _mapper.Map<List<ProductViewModel>>(products).AddLinks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProductById(long id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
                return NotFound("product not found");

            return _mapper.Map<ProductViewModel>(product).AddLinks();
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
