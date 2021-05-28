using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Core.Layers
{
    public class BusinessLayer : IBusinessLayer
    {

        private readonly IOrderRepository orderRepo;
        private readonly IClientRepository clientRepo;

        public BusinessLayer(IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public BusinessLayer(IClientRepository clientRepo)
        {
            this.clientRepo = clientRepo;
        }

        #region Order

        public IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null)
        {
            return orderRepo.Fetch();
        }

        public Order FetchOrderByID(int id)
        {
            return orderRepo.GetById(id);
        }

        public bool CreateOrder(Order newOrder)
        {
            return orderRepo.Add(newOrder);
        }

        public bool EditOrder(Order editedOrder)
        {
            return orderRepo.Update(editedOrder);
        }
        public bool DeleteOrder(Order orderToBeDeleted)
        {
            return orderRepo.Delete(orderToBeDeleted);
        }


        public bool PlaceAnOrder(string orderCode, string productCode, decimal amount, int clientId)
        {
            return orderRepo.Add(new Order
            {
                OrderDate = DateTime.Now,
                OrderCode = orderCode,
                ProductCode = productCode,
                Amount = amount,
                ClientId = clientId,
            }) ;
        }
        public bool CancelOrder(int idOrder)
        {
            var orderRecord = orderRepo.Fetch().FirstOrDefault(o => o.ID == idOrder);

            if (orderRecord != null)
                return orderRepo.Delete(orderRecord);
            
            return true;
        }

        #endregion


        #region Client
        public IEnumerable<Client> FetchClients()
        {
            throw new NotImplementedException();
        }
        public Client FetchClientByID(int id)
        {
            throw new NotImplementedException();
        }
        public bool CreateProfile(Client newClient)
        {
            throw new NotImplementedException();
        }
        public bool EditProfile(Client editedClient)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProfile(Client clientToBeDelited)
        {
            throw new NotImplementedException();
        }
        #endregion







       

     

       
       

       
    }
}
