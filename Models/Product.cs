using System.Collections.Generic;

namespace eCommerceAssessment.Models
{
    public class Product
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public int stock { get; set; }
        public List<Order> orders { get; set; }
    }
}
