using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using TravelTogether.Application.Exceptions;
using TravelTogether.Application.Interfaces;
using TravelTogether.Application.Interfaces.Repositories;
using TravelTogether.Application.Wrappers;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Infrastructure.Shared.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public UserService(IUserRepository userRepository, IAuthService authService, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _authService = authService;
        _logger = logger;
    }

    public async Task<Response<User>> GetCurrentUser(string token)
    {
        _logger.Log(LogLevel.Debug, "Start get-current-user service method");
        _logger.Log(LogLevel.Trace, token);

        if (token == null)
        {
            _logger.Log(LogLevel.Error, "User token not contains in headers");
            return new Response<User>("No user token");
        }
        
        

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadToken(token) as JwtSecurityToken;
        
        var userId = jwt.Claims.First(claim => claim.Type == "jti").Value;


        var user = _userRepository.GetAllAsync().FirstOrDefault(u => u.Id == Guid.Parse(userId));

        if (user == null)
        {
            _logger.Log(LogLevel.Error, "User with provided ID not found in database");
            return new Response<User>("User not found");
        }
        
        
        _logger.Log(LogLevel.Information, JsonSerializer.Serialize(user));

        return new Response<User>(user);


    }
}