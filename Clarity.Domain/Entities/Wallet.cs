using System;
using System.Collections.Generic;
using System.Text;

namespace Clarity.Domain.Entities
{
    public class Wallet
    {
        public Guid UID { get; set; }
        public User User { get; set; }

        public ICollection<WalletTransaction> WalletTransactions { get; private set; } = new HashSet<WalletTransaction>();
    }
}
