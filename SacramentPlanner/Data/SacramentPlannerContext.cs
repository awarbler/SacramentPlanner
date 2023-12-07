using Microsoft.EntityFrameworkCore;

namespace SacramentPlanner.Data
{
    public class SacramentPlannerContext : DbContext
    {
        public SacramentPlannerContext (DbContextOptions<SacramentPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentPlanner.Models.Meeting> Meeting { get; set; } = default!;
    }
}
