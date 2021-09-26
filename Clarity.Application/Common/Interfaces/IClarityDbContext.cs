using Clarity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clarity.Application.Common.Interaces
{
    public interface IClarityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        
    }
}