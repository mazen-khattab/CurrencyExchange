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
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasOne(p => p.Currency)
                .WithMany(p => p.Countries)
                .HasForeignKey(p => p.CurrencyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.CountryName).IsRequired();

            builder.Property(p => p.CountryCode).IsRequired();
        }
    }
}
