using System;
using System.Collections.Generic;
using TravelTogether.Domain.Enums;

namespace TravelTogether.Domain.Entities;

public class Destination
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public Location Coordinates { get; set; }
    public ICollection<PointOfInterest> PointsOfInterest { get; set; }
    public PointOfInterestCategory Category { get; set; }
}