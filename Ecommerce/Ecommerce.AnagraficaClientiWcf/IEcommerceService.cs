using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ecommerce.AnagraficaClientiWcf
{

    [ServiceContract]
    public interface IEcommerceService
    {
        [OperationContract]
        List<Client> GetClients();

        [OperationContract]
        Client GetClientById(int id);

        [OperationContract]
        bool AddNewClient(Client newClient);

        [OperationContract]
        bool EditClient(Client updatedClient);

        [OperationContract]
        bool DeleteClientById(int id);


    }

}