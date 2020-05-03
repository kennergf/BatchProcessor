using BatchProcessor.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BatchProcessor.Data.Data
{
    public class BPContext : IdentityDbContext<User>
    {
        public DbSet<Number> Numbers { get; set; }

        public BPContext(DbContextOptions<BPContext> options) : base(options)
        {
            
        }
    }
}