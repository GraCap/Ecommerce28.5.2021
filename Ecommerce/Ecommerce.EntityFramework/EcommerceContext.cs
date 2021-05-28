using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.EntityFramework
{
    public class EcommerceContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        #region Ctors
        public EcommerceContext() : base() { }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {

        }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E-commerce;
                                            Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                            TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
        }
    }
}
