using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelTogether.Application.Interfaces;
using TravelTogether.Application.Interfaces.Repositories;
using TravelTogether.Application.Wrappers;
using TravelTogether.Domain.Entities;
using TravelTogether.Domain.Enums;

namespace TravelTogether.Infrastructure.Shared.Services;

public class TravelService : ITravelService
{

    private readonly ITravelRepository _travelRepository;

    public TravelService(ITravelRepository travelRepository)
    {
        _travelRepository = travelRepository;
    }


    public async Task<Response<Travel>> GetTravelById(Guid travelId)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<IEnumerable<Travel>>> GetUserTravels(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Travel>> UpdateTravel(Guid travelId)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Travel>> CreateTravel(Travel newEntry)
    {

        if (
            newEntry.TripName != null && 
            newEntry.Destination != null && 
            newEntry.StartDate != null && 
            newEntry.EndDate != null
            )
        {
            newEntry.TripStatus = TripStatus.Planned;
        }
        else
        {
            newEntry.TripStatus = TripStatus.InProgress;
        }
        
        newEntry.Id = Guid.NewGuid();


        var createdEntity  =await _travelRepository.AddAsync(newEntry);

        return new Response<Travel>(createdEntity);
    }
}