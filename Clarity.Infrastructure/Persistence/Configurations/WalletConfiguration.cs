using Clarity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clarity.Infrastructure.Persistence.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.Property<int>("ID");

            builder.HasKey("ID");

            builder.HasOne(a => a.User)
                .WithOne(a => a.Wallet)
                .HasForeignKey<Wallet>("ID");
        }
    }
}
