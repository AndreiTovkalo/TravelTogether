using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Application.Interfaces.Repositories;

public interface ITravelRepository : IGenericRepositoryAsync<Travel>
{
    Task<IEnumerable<Travel>> GetAllByUserId(Guid userId);
}