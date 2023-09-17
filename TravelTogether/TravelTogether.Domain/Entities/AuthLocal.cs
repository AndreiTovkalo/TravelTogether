using System;
using TravelTogether.Domain.Common;

namespace TravelTogether.Domain.Entities;

public class AuthLocal : AuditableBaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
}