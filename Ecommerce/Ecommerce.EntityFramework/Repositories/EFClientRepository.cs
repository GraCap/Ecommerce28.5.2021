using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.EntityFramework.Repositories
{
    public class EFClientRepository : IClientRepository
    {
        private readonly EcommerceContext ctx;

        #region Ctors
        public EFClientRepository() : this(new EcommerceContext()) { }

        public EFClientRepository(EcommerceContext ctx)
        {
            this.ctx = ctx;
        }
        #endregion


        public bool Add(Client newClient)
        {
            try
            {
                ctx.Clients.Add(newClient);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Client> Fetch()
        {
            try
            {
                return ctx.Clients.ToList();
            }
            catch (Exception)
            {
                return new List<Client>();
            }
        }


        public Client GetById(int id)
        {
            try
            {
                var client = ctx.Clients.Include(c => c.Orders)
                    .FirstOrDefault(c => c.ID == id);
                return client;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Client updatedClient)
        {
            try
            {
                ctx.Clients.Update(updatedClient);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Client clientToBeDeleted)
        {
            try
            {
                var client = ctx.Clients.Find(clientToBeDeleted.ID);

                if (client != null)
                    ctx.Clients.Remove(client);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
