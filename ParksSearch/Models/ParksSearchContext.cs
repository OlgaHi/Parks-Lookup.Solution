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
    }
}