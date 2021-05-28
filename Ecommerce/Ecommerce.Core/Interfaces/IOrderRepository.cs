using Ecommerce.Core.Entities;
using System.Collections.Generic;

namespace Ecommerce.Core.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> Fetch();
        Order GetById(int id);
        bool Add(Order item);
        bool Update(Order item);
        bool Delete(Order item);
    }
}
