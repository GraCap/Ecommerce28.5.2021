using Ecommerce.Core.Entities;
using System.Collections.Generic;

namespace Ecommerce.Core.Interfaces
{
    public interface IClientRepository
    {
        List<Client> Fetch();
        Client GetById(int id);
        bool Add(Client item);
        bool Update(Client item);
        bool Delete(Client item);
    }

}