﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Api.Controllers
{
    [Route("Product/[controller]")]
    [ApiController]
    public class IMageProductController : ControllerBase
    {
        [HttpPost("{productId}")]
        public async Task<IActionResult> AddProductImage(long productId)
        {
            //
            return Ok();
        }
    }
}
