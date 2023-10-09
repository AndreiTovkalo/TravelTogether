using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelTogether.Application.Interfaces.Repositories;
using TravelTogether.Domain.Entities;
using TravelTogether.Infrastructure.Persistence.Contexts;

namespace TravelTogether.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{

    private readonly ApplicationDbContext _dbContext;
    
    
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<User>().FindAsync(id);
    }

    // public async Task<IEnumerable<User>> GetPagedResponseAsync(int pageNumber, int pageSize)
    // {
    //     return await _dbContext.Users
    //         .Skip((pageNumber - 1) * pageSize).Take(pageSize)
    //         .AsNoTracking()
    //         .ToListAsync();
    // }


    public async Task<User> AddAsync(User entity)
    {
        await _dbContext.Set<User>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(User entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User entity) {
        _dbContext.Set<User>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public ICollection<User> GetAllAsync()
    {
        return _dbContext.Users.Include(u => u.AuthLocal).ToList();
    }


}
    