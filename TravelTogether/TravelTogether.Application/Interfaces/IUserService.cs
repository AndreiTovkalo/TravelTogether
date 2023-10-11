using System;
using System.Threading.Tasks;
using TravelTogether.Application.Wrappers;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Application.Interfaces;

public interface IUserService
{
    // Task<User> GetUserById(Guid id);
    // Task<User> CreateUser(User user);
    Task<Response<User>> GetCurrentUser(string token);
}