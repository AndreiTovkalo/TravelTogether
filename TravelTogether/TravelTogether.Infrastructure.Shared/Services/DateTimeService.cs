using System;
using TravelTogether.Application.Interfaces;

namespace TravelTogether.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}