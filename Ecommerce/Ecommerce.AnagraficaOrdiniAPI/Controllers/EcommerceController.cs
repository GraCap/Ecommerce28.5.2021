using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Core.Layers;
using Ecommerce.EntityFramework.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.AnagraficaOrdiniAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        private BusinessLayer bl;
        IOrderRepository orderRepo = new EFOrderRepository();

        //private LibraryContext ctx;
        public EcommerceController()
        {
            this.bl = new BusinessLayer(orderRepo);
        }

        #region HTTP REQUEST FOR ORDERS
        
        [HttpGet]
        public ActionResult Get()
        {
            var orders = this.bl.FetchOrders();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if (id==0)
                return NotFound($"Order with ID: {id} is missing");

            var order = this.bl.FetchOrderByID(id);
            if (order == null)
                return NotFound("Order not found");

            return Ok(order);
        }

        //non capisco perchè non funzioni
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order editedOrder)  
        {
            if (editedOrder == null)
                return BadRequest("Invalid Order data.");

            if (id != editedOrder.ID)
                return BadRequest("Order ID don't match!");

            this.bl.EditOrder(editedOrder);

            return Ok();   
        }

        //sorry neanche questa funziona
        [HttpPost]
        public ActionResult Post([FromBody] Order newOrder) //Action
        {
            if (newOrder == null)
                return BadRequest("Invalid Order data.");

            this.bl.CreateOrder(newOrder);

            return Created($"/order/{newOrder.ID}", newOrder); 
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            if (id==0)
                return NotFound($"Invalid ID: {id}.");

            var orderToBeDeleted = this.bl.FetchOrderByID(id);

            if (orderToBeDeleted != null)
                this.bl.DeleteOrder(orderToBeDeleted);

            return Ok();  
        }
        #endregion

        #region HTTP PRAGMATIC REQUEST

        [HttpPost("{orderCode}/order/{productCode}/loan/{amount}/loan/{clientId}")]
        public ActionResult PostNewOrder(string orderCode, string productCode, decimal amount, int clientId) //Action
        {
            var result = this.bl.PlaceAnOrder(orderCode, productCode, amount, clientId);

            if (!result)
                return BadRequest($"Cannot place a new order with Code = {orderCode}.");

            return Created($"Order [Code: {orderCode}] [Product Code: {productCode}] [Amount: {amount}] [Buyer Id: {clientId}]", ""); 
        }

        [HttpPost("{id}/return")]
        public ActionResult CancelOrder(int id)
        {
            var result = this.bl.CancelOrder(id);

            if (!result)
                return BadRequest($"Error processing the cancellation of Order with ID = {id}."); 

            return Ok($"Order with ID = {id} has been successfully cancelled"); 
        }
        #endregion

    }
}
