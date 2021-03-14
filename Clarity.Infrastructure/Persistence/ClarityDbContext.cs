using System.Reflection;
using Ironwood.Application.Common.Interaces;
using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Infrastructure.Persistence
{
    public class ClarityDbContext : DbContext, IClarityDbContext
    {
        public DbSet<User> Users { get ; set; }

        public ClarityDbContext(DbContextOptions<ClarityDbContext> dbContext) : base (dbContext)
		{ 		
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
    }
}