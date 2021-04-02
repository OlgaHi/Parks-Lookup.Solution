using Microsoft.EntityFrameworkCore;

namespace ParksSearch.Models
{
    public class ParksSearchContext : DbContext
    {
        public ParksSearchContext(DbContextOptions<ParksSearchContext> options)
            : base(options)
        {
        }

        public DbSet<NationalPark> NationalParks { get; set; }
        public DbSet<StatePark> StateParks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NationalPark>()
                .HasData(
                    new NationalPark { Id = 1, Name = "Olympic Park", Address = "3002 Mt Angeles Rd, Port Angeles, WA", WheelchairAccess = true },
                    new NationalPark { Id = 2, Name = "Mountain Rainier Park", Address = "55210 238th Avenue East, Ashford, WA", WheelchairAccess = false },
                    new NationalPark { Id = 3, Name = "Paradise", Address = "3256 Road, Paradise, WA", WheelchairAccess = true }
                    );

            builder.Entity<StatePark>()
                .HasData(
                    new StatePark { Id = 1, Name = "Bridle Trails", Address = "5300 116th Ave NE, Kirkland, WA", WheelchairAccess = true },
                    new StatePark { Id = 2, Name = "Saint Edward", Address = "555 NE, Kenmore, WA", WheelchairAccess = true },
                    new StatePark { Id = 3, Name = "Kitsap Memorial", Address = "1111 NE 136 St, Poulsbo, WA", WheelchairAccess = true }
                    );
        }
    }
}