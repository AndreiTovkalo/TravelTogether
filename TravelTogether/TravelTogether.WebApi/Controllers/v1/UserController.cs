using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelTogether.Application.DTOs.Auth;
using TravelTogether.Application.Interfaces;
using TravelTogether.Domain.Entities;

namespace TravelTogether.WebApi.Controllers.v1;

[Authorize]
[ApiVersion("1.0")]
[Route("users")]
public class UserController : BaseApiController
{

    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public UserController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpGet]
    [Route("get-current-user")]
    public async Task<IActionResult> GetCurrentUserInfo()
    {
        return Ok(new { text= "Hello" });
    }

    // [HttpGet]
    // [Route("get-user")]
    // public async Task<IActionResult> GetUser([FromBody] string id)
    // {
    //     return Ok(await _userService.GetUserById(id));
    // }
    
    // [HttpPut]
    // [Route("edit-user")]
    // public async Task<IActionResult> UpdateUser([FromBody] User user)
    // {
    //     return Ok(await _userService.EditUserInfo(user));
    // }

    [HttpPost]
    [AllowAnonymous]
    [Route("register")]
    public async Task<IActionResult> CreateUser([FromBody] RegisterRequest request)
    {
        return Ok(await _authService.Register(request));
    }


    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request) => Ok(await _authService.Login(request));
}