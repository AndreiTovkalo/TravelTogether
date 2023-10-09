namespace TravelTogether.Domain.Entities;

public class AuthorizeResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}