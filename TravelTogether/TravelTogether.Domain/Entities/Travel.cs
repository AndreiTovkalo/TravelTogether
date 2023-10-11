using System;
using System.Collections.Generic;
using TravelTogether.Domain.Common;
using TravelTogether.Domain.Enums;

namespace TravelTogether.Domain.Entities;

public class Travel : AuditableBaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string TripName { get; set; }
    public string Description { get; set; }
    public Destination Destination { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime EndDate { get; set; } = DateTime.Now.ToLocalTime().AddDays(7);
    public TripType TripType { get; set; }
    public ICollection<User> Travelers { get; set; } = new List<User>();
    public TripStatus TripStatus { get; set; }


}