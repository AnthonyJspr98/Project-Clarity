using Clarity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clarity.Infrastructure.Persistence.Configurations
{
    public class WalletTransactionConfiguration : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.Property<int>("ID");
            builder.HasKey("ID");

            builder.HasOne(a => a.Wallet)
                .WithMany(a => a.WalletTransactions)
                .HasForeignKey("WalletID");

            builder.Property<Decimal>("Amount")
               .HasColumnType($"DECIMAL(20,8)");
        }
    }
}
