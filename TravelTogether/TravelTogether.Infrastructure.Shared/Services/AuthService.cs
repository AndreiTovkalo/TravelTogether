using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TravelTogether.Application.DTOs.Auth;
using TravelTogether.Application.Exceptions;
using TravelTogether.Application.Interfaces;
using TravelTogether.Application.Interfaces.Repositories;
using TravelTogether.Application.Wrappers;
using TravelTogether.Domain.Entities;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace TravelTogether.Infrastructure.Shared.Services;

public class AuthService : IAuthService
{
    
    const int KeySize = 64;
    const int Iterations = 350000;
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;
    
    private readonly IConfiguration _config;


    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository, IConfiguration config)
    {
        _userRepository = userRepository;
        _config = config;
    }

    

    public async Task<Response<AuthorizeResponse>> Login(LoginRequest request)
    {
        var dbUser = _userRepository.GetAllAsync().FirstOrDefault(u => u.AuthLocal.Email == request.Email);

        if (dbUser == null)
        {
            return new Response<AuthorizeResponse>("User not found");
        }


        if (!VerifyPassword(request.Password, dbUser.AuthLocal.PasswordHash, dbUser.AuthLocal.Salt))
        {
            throw new ApiException("Password not correct");
            
        }
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, dbUser.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, dbUser.AuthLocal.Email),
            new Claim(JwtRegisteredClaimNames.Jti, dbUser.Id.ToString()) //todo: Add claims
        };

        var accessToken = await GenerateAccessToken(claims);
        var refreshToken = "Plug for refresh token";

        var response = new AuthorizeResponse()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return new Response<AuthorizeResponse>(response);
        
        
        
        
        Console.WriteLine(JsonSerializer.Serialize(dbUser));
        return null;
    }

    public async Task<Response<AuthorizeResponse>> Register(RegisterRequest request)
    {
        
        
        // var dbUser = _userRepository.GetAllAsync().First(u => u.AuthLocal.Email == request.Email);
        //
        //
        //
        // if (dbUser != null)
        // {
        //     throw new ApiException("User with this email already exist");
        // }

        var passwordHash = HashPassword(request.Password, out byte[] salt);
        Console.WriteLine("Start register service");

        AuthLocal authLocal = new AuthLocal()
        {
            Email = request.Email,
            PasswordHash = passwordHash,
            Salt = salt
            
        };

        var user = new User()
        {
            AuthLocal = authLocal,
            Name = request.Name,
            Surname = request.Surname
        };
        authLocal.UserId = user.Id;

        await _userRepository.AddAsync(user);
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.AuthLocal.Email),
            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()) //todo: Add claims
        };
        

        var accessToken = await GenerateAccessToken(claims);
        // var refreshToken = await GenerateRefreshToken();

        var response = new AuthorizeResponse()
        {
            AccessToken = accessToken,
            RefreshToken = "Test refresh token plug"
        };

        return new Response<AuthorizeResponse>(response);

    }

    public async Task<string> GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C1CF4B7DC4C4175B6618DE4F55CA4"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenOptions = new JwtSecurityToken(
            issuer: "CoreIdentity",
            audience: "CoreIdentityUser",
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signinCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions); 
        return tokenString;
    }

    public async Task<string> GenerateRefreshToken()
    {
        throw new System.NotImplementedException();
    }

    public async Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
    {
        throw new System.NotImplementedException();
    }
    
    
    
    private string HashPassword(string password, out byte[] salt)
    {
        Console.WriteLine("Password hash");
        salt = RandomNumberGenerator.GetBytes(KeySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            350000,
            HashAlgorithm, 
            KeySize);
        return Convert.ToHexString(hash);
    }
    
    private bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithm, KeySize);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
    
}