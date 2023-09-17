using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelTogether.Application.Interfaces;
using TravelTogether.Domain.Entities;

namespace TravelTogether.WebApi.Controllers.v1;

[Authorize]
[ApiVersion("1.0")]
[Route("users")]
public class UserController : BaseApiController
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // [HttpGet]
    // [Route("get-current-user")]
    // public async Task<IActionResult> GetCurrentUserInfo()
    // {
    //     return Ok(await _userService.());
    // }

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
    [Route("create")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        return Ok(await _userService.CreateUser(user));
    }
}