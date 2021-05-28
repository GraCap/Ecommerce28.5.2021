using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;

namespace Ecommerce.Core.Interfaces
{
    public interface IBusinessLayer
    {
        #region Order
        IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null);
        bool CreateOrder(Order newOrder);
        bool EditOrder(Order editedOrder);
        bool DeleteOrder(Order orderToBeDeleted);
        Order FetchOrderByID(int id);

        
        bool PlaceAnOrder(string orderCode, string productCode, decimal amount, int clientId);
        bool CancelOrder(int idOrder);

        #endregion

        #region CLient

        IEnumerable<Client> FetchClients();
        bool CreateProfile(Client newClient);
        bool EditProfile(Client editedClient);
        bool DeleteProfile(Client clientToBeDelited);
        Client FetchClientByID(int id);

        #endregion
    }
}