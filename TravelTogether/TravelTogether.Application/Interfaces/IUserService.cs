using System;
using System.Threading.Tasks;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Application.Interfaces;

public interface IUserService
{
    // Task<User> GetUserById(Guid id);
    Task<User> CreateUser(User user);
}