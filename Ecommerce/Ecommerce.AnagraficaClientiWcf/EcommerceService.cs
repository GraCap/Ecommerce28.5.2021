using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Core.Layers;
using Ecommerce.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ecommerce.AnagraficaClientiWcf
{
    public class EcommerceService : IEcommerceService
    {
        IBusinessLayer bl;

        public EcommerceService()
        {
            var clientRepo = new EFClientRepository();
            bl = new BusinessLayer(clientRepo);
        }


        public bool AddNewClient(Client newClient)
        {
            try
            {
                return bl.CreateProfile(newClient);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClientById(int id)
        {
            try
            {
                var client = GetClientById(id);

                return bl.DeleteProfile(client);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditClient(Client updatedClient)
        {
            try
            {
                return bl.EditProfile(updatedClient);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Client GetClientById(int id)
        {
            return bl.FetchClientByID(id);
        }

        public List<Client> GetClients()
        {
            try
            {
                return bl.FetchClients().ToList();
            }
            catch (Exception)
            {
                return new List<Client>();
            }
        }
    }
}
