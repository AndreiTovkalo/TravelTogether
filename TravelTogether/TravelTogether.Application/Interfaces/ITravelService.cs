using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelTogether.Application.Wrappers;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Application.Interfaces;

public interface ITravelService
{
    Task<Response<Travel>> GetTravelById(Guid travelId);
    Task<Response<IEnumerable<Travel>>> GetUserTravels(Guid userId);
    Task<Response<Travel>> UpdateTravel(Guid travelId);
    Task<Response<Travel>> CreateTravel(Travel newEntry);


}