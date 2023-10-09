using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);

    ICollection<User> GetAllAsync();

    // Task<IEnumerable<User>> GetPagedReponseAsync(int pageNumber, int pageSize);
    //
    // Task<IEnumerable<User>> GetPagedAdvancedReponseAsync(int pageNumber, int pageSize, string orderBy, string fields);

    Task<User> AddAsync(User entity);

    Task UpdateAsync(User entity);

    Task DeleteAsync(User entity);
}