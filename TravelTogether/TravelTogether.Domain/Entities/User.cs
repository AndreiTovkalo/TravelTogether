using System;
using System.Collections.Generic;
using TravelTogether.Domain.Common;
using TravelTogether.Domain.Enums;

namespace TravelTogether.Domain.Entities;

public class User : AuditableBaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public AuthLocal AuthLocal { get; set; }
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
    public string ProfilePictureUrl { get; set; }
    public ICollection<Travel> Travels { get; set; } = new List<Travel>();
}