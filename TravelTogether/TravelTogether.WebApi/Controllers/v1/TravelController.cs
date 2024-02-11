using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelTogether.WebApi.Controllers.v1;


[Authorize]
[ApiVersion("1.0")]
[Route("travels")]
public class TravelController : BaseApiController
{



    
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetUserTravels()
    {
        return Ok();
    }
}