using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityFramework
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder
                .HasKey(o => o.ID);

            builder
                .Property(o => o.OrderDate)
                 .HasColumnType("date")
                .IsRequired();

            builder
                .Property(o => o.OrderCode)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(o => o.ProductCode)
                .HasMaxLength(50)
                .IsRequired();

            builder
               .Property(o => o.Amount)
               .HasColumnType("money")
               .IsRequired();

            builder
                .HasOne(c => c.Client)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.ClientId);
        }
    }
}