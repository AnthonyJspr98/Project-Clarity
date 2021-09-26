using System.Reflection;
using Clarity.Application.Common.Interaces;
using Clarity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Infrastructure.Persistence
{
    public class ClarityDbContext : DbContext, IClarityDbContext
    {
        public DbSet<User> Users { get ; set; }
		public DbSet<Wallet> Wallets { get ; set; }
		public DbSet<WalletTransaction> WalletTransactions { get ; set ; }

		public ClarityDbContext(DbContextOptions<ClarityDbContext> dbContext) : base (dbContext)
		{ 		
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}