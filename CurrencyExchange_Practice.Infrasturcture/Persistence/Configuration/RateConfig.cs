using CurrencyExchange_Practice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Infrasturcture.Persistence.Configuration
{
    public class RateConfig : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.HasOne(p => p.Currency)
                .WithMany(p => p.Rates)
                .HasForeignKey(p => p.CurrencyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Rate).IsRequired();

            builder.Property(p => p.Date).IsRequired();
        }
    }
}
