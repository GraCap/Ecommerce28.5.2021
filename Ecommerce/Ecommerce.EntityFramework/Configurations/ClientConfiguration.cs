using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.EntityFramework
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
               .HasKey(c => c.ID);

            builder
                .Property(c => c.ClientCode)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}