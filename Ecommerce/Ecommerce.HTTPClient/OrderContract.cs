using System;

namespace Ecommerce.HTTPClient
{
    public class OrderContract
    {
        public int ID { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderCode { get; set; }

        public string ProductCode { get; set; }

        public decimal Amount { get; set; }

        public int ClientId { get; set; }

        
    }
}