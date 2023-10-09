using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelTogether.Application.DTOs.Auth;
using TravelTogether.Application.Wrappers;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Application.Interfaces;

public interface IAuthService
{
    Task<Response<AuthorizeResponse>> Login(LoginRequest request);
    Task<Response<AuthorizeResponse>> Register(RegisterRequest request);
    Task<string> GenerateAccessToken(IEnumerable<Claim> claims);
    Task<string> GenerateRefreshToken();
    Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
}