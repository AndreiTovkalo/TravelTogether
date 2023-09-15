using AutoMapper;
using TravelTogether.Application.Features.Employees.Queries.GetEmployees;
using TravelTogether.Application.Features.Positions.Commands.CreatePosition;
using TravelTogether.Application.Features.Positions.Queries.GetPositions;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Position, GetPositionsViewModel>().ReverseMap();
            CreateMap<Employee, GetEmployeesViewModel>().ReverseMap();
            CreateMap<CreatePositionCommand, Position>();
        }
    }
}