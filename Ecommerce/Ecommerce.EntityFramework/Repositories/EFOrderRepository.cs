using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.EntityFramework.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly EcommerceContext ctx;

        #region Ctors
        public EFOrderRepository() : this(new EcommerceContext()) { }

        public EFOrderRepository(EcommerceContext ctx)
        {
            this.ctx = ctx;
        }
        #endregion


        public bool Add(Order newOrder)
        {
            try
            {
                ctx.Orders.Add(newOrder);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    
        public List<Order> Fetch()
        {
            try
            {
                return ctx.Orders.ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }


        public Order GetById(int id)
        {
            try
            {
                var order = ctx.Orders.Find(id);
                return order;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Order updatedOrder)
        {
            try
            {
                ctx.Orders.Update(updatedOrder);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Order orderToBeDeleted)
        {
            try
            {
                var order = ctx.Orders.Find(orderToBeDeleted.ID);

                if (order != null)
                    ctx.Orders.Remove(order);
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

