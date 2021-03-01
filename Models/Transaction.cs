using System.Collections.Generic;

namespace eCommerceAssessment.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public float total { get; set; }
        public User user { get; set; }
        public int userid { get; set; }
        public ShippingProvider shippingProvider { get; set; }
        public int shippingProviderid { get; set; }
        public Address shippingAddress { get; set; }
        public int shippingAddressid { get; set; }
        public List<Order> orders { get; set; }

    }
}
