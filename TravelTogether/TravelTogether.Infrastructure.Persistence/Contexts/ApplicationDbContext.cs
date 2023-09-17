using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TravelTogether.Application.Interfaces;
using TravelTogether.Domain.Common;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        // private readonly IDateTimeService _dateTime;
        // private readonly ILoggerFactory _loggerFactory;

        // public ApplicationDbContext()
        // {
        //     
        // }
        //
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
            // IDateTimeService dateTime,
            // ILoggerFactory loggerFactory
            ) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            // _dateTime = dateTime;
            // _loggerFactory = loggerFactory;
        }

        // public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            // {
            //     switch (entry.State)
            //     {
            //         case EntityState.Added:
            //             entry.Entity.Created = _dateTime.NowUtc;
            //             break;
            //
            //         case EntityState.Modified:
            //             entry.Entity.LastModified = _dateTime.NowUtc;
            //             break;
            //     }
            // }
            return base.SaveChangesAsync(cancellationToken);
        }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     var _mockData = this.Database.GetService<IMockService>();
        //     var seedPositions = _mockData.SeedPositions(1000);
        //     builder.Entity<Position>().HasData(seedPositions);
        //
        //     base.OnModelCreating(builder);
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=root;database=travel_together;port=8889", new MySqlServerVersion(new Version(5,7,39)));
            // optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}