using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelTogether.Application.Interfaces.Repositories;
using TravelTogether.Domain.Entities;
using TravelTogether.Infrastructure.Persistence.Contexts;

namespace TravelTogether.Infrastructure.Persistence.Repositories;

public class TravelRepository : GenericRepositoryAsync<Travel>, ITravelRepository
{

    private readonly ApplicationDbContext _dbContext;
    
    public TravelRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Travel>> GetAllByUserId(Guid userId)
    {
       return _dbContext.Travels.Include(t => t.Travelers)
           .Include(t => t.Destination)
           .ThenInclude(d => d.Coordinates)
           .Where(t => t.Travelers.First().Id == userId);
    }

}