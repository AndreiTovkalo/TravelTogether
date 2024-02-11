using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelTogether.Application.Interfaces;
using TravelTogether.Domain.Entities;

namespace TravelTogether.WebApi.Controllers.v1;


[Authorize]
[ApiVersion("1.0")]
[Route("travels")]
public class TravelController : BaseApiController
{
    private readonly ITravelService _travelService;

    public TravelController(ITravelService travelService)
    {
        _travelService = travelService;
    }


    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetUserTravels()
    {
        return Ok();
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateTravel(Travel travel)
    {
        try
        {
            return Ok(await _travelService.CreateTravel(travel));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}