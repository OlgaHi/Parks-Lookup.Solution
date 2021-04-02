using Microsoft.EntityFrameworkCore;

namespace ParksSearch.Models
{
    public class CretaceousParkContext : DbContext
    {
        public ParksSearchContext(DbContextOptions<ParksSearchkContext> options)
            : base(options)
        {
        }

        public DbSet<NationalPark> NationalParks { get; set; }
        public DbSet<StatePark> StateParks { get; set; }
    }
}