using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelTogether.Application.Exceptions;
using TravelTogether.Application.Interfaces;
using TravelTogether.Application.Interfaces.Repositories;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Infrastructure.Shared.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    public async Task<User> CreateUser(User user)
    {
        var dbUsers = await _userRepository.GetAllAsync();

        if (dbUsers.ToList().Any(u => u.AuthLocal.Email == user.AuthLocal.Email))
        {
            throw new ApiException("User with this email already exist");
        }

        var createdUser = await _userRepository.AddAsync(user);

        return createdUser;

    }
}