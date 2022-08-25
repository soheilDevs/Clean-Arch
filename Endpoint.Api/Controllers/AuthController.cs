using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Users.Register;
using MediatR;

namespace Endpoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUsers(RegisterUserCommand command)
        {

            var result =await _mediator.Send(command);
            return Created("",result);
        }
    }
}
