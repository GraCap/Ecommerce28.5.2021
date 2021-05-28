using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Ecommerce.Core.Entities
{ 
    [DataContract]
    public class Order
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public string OrderCode { get; set; }

        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
