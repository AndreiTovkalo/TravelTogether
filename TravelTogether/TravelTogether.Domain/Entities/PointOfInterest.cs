using System;
using TravelTogether.Domain.Enums;

namespace TravelTogether.Domain.Entities;

public class PointOfInterest
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public Location Coordinates { get; set; }
    public PointOfInterestCategory Category { get; set; } 

}