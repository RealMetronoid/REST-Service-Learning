using Microsoft.EntityFrameworkCore;

namespace JobREST.Models
{
    public class JobDBContext : DbContext
    {
        public JobDBContext(DbContextOptions<JobDBContext> options) : base(options)
        {
            
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
