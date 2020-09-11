using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Iot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult SetResponse(dynamic response)
        {
            if (response.Status == HttpStatusCode.OK)
            {
                return Ok(response.Response);
            }
            else if (response.Status == HttpStatusCode.NotFound)
            {
                return NotFound(response.Response);
            }
            else if (response.Status == HttpStatusCode.Conflict)
            {
                return Conflict(response.Response);
            }
            else if (response.Status == HttpStatusCode.InternalServerError)
            {
                return StatusCode(500, response.Response);
            }
            else if (response.Status == HttpStatusCode.BadRequest)
            {
                return BadRequest(response.Response);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
