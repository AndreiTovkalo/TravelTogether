using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelTogether.WebApi.Controllers.v1;

[Authorize]
[ApiVersion("1.0")]
[Route("auth")]
public class AuthController : BaseApiController
{

    public AuthController()
    {
        
    }
    
}